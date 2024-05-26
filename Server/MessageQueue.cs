using System.Collections.Concurrent;

namespace Server.Library {
    public class MessageQueue {
        private static readonly MessageQueue instance = new();

        public static MessageQueue Instance => instance;

        public readonly ConcurrentQueue<string> MessageLog = new();
        public readonly ConcurrentQueue<string> DebugLog = new();
        public readonly ConcurrentQueue<string> ChatLog = new();

        public MessageQueue() { }

        public void Enqueue(string msg) {
            if(MessageLog.Count < 100) {
                MessageLog.Enqueue(String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            }

            Logger.GetLogger(LogType.Server).Info(msg);
        }

        public void Enqueue(Exception ex) {
            if(MessageLog.Count < 100) {
                MessageLog.Enqueue(String.Format("[{0}]: {1} - {2}" + Environment.NewLine, DateTime.Now, ex.TargetSite,
                    ex));
            }

            Logger.GetLogger(LogType.Server).Error(ex);
        }

        public void EnqueueDebugging(string msg) {
            if(DebugLog.Count < 100) {
                DebugLog.Enqueue(String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            }

            Logger.GetLogger(LogType.Debug).Debug(msg);
        }

        public void EnqueueChat(string msg) {
            if(ChatLog.Count < 100) {
                ChatLog.Enqueue(String.Format("[{0}]: {1}" + Environment.NewLine, DateTime.Now, msg));
            }

            Logger.GetLogger(LogType.Chat).Info(msg);
        }
    }
}

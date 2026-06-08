using System;
using System.Net.Sockets;

namespace MLAPI.Transports.Tasks
{
	public class SocketTask
	{
		public bool IsDone { get; set; }

		public bool Success { get; set; }

		public Exception TransportException { get; set; }

		public SocketError SocketError { get; set; }

		public int TransportCode { get; set; }

		public string Message { get; set; }

		public object State { get; set; }

		public static SocketTask Done => new SocketTask
		{
			IsDone = true,
			Message = null,
			SocketError = SocketError.Success,
			State = null,
			Success = true,
			TransportCode = -1,
			TransportException = null
		};

		public static SocketTask Fault => new SocketTask
		{
			IsDone = true,
			Message = null,
			SocketError = SocketError.SocketError,
			State = null,
			Success = false,
			TransportCode = -1,
			TransportException = null
		};

		public static SocketTask Working => new SocketTask
		{
			IsDone = false,
			Message = null,
			SocketError = SocketError.SocketError,
			State = null,
			Success = false,
			TransportCode = -1,
			TransportException = null
		};

		public SocketTasks AsTasks()
		{
			SocketTasks socketTasks = new SocketTasks();
			socketTasks.Tasks = new SocketTask[1] { this };
			return socketTasks;
		}
	}
}

using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public class NewSessionTicket
	{
		protected readonly long mTicketLifetimeHint;

		protected readonly byte[] mTicket;

		public virtual long TicketLifetimeHint => 0L;

		public virtual byte[] Ticket => null;

		public NewSessionTicket(long ticketLifetimeHint, byte[] ticket)
		{
		}

		public virtual void Encode(Stream output)
		{
		}

		public static NewSessionTicket Parse(Stream input)
		{
			return null;
		}
	}
}

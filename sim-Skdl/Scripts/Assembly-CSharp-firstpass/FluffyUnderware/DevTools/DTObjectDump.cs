using System.Reflection;
using System.Text;

namespace FluffyUnderware.DevTools
{
	public class DTObjectDump
	{
		private const int INDENTSPACES = 5;

		private string mIndent;

		private StringBuilder mSB;

		private object mObject;

		public DTObjectDump(object o, int indent = 0)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void AppendHeader(string name)
		{
		}

		private void AppendMember(MemberInfo info)
		{
		}
	}
}

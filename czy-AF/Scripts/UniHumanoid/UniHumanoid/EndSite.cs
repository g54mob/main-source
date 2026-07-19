using System.IO;

namespace UniHumanoid
{
	public class EndSite : BvhNode
	{
		public EndSite()
			: base("")
		{
		}

		public override void Parse(StringReader r)
		{
			r.ReadLine();
		}
	}
}

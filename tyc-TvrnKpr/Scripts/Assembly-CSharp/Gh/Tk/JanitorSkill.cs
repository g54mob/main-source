using System.Text;

namespace Gh.Tk
{
	public class JanitorSkill : StaffSkill
	{
		protected JanitorSkill()
		{
		}

		public JanitorSkill(Staff owner)
		{
		}

		protected override void AppendEffectDetailsForTooltip(StringBuilder sb)
		{
		}

		public float GetCleanSpeedFactor()
		{
			return 0f;
		}
	}
}

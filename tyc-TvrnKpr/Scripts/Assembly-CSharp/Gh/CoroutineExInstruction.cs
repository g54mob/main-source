using Gh.Tk;

namespace Gh
{
	public class CoroutineExInstruction
	{
		protected CoroutineEx Owner => null;

		public virtual bool ContinueOnSameFrame => false;

		public virtual bool Update()
		{
			return false;
		}

		public virtual void Finish()
		{
		}
	}
}

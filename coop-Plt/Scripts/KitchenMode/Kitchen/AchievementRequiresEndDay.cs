using Unity.Entities;

namespace Kitchen
{
	public abstract class AchievementRequiresEndDay<T> : AchievementManager<T> where T : struct, IComponentData
	{
		protected abstract bool IsSatisfied(T data);

		protected abstract void Reset(ref T data);

		protected abstract void Check(ref T data);

		protected override void HandleUpdate(ref T data)
		{
			if (Has<SIsNightTime>())
			{
				if (IsSatisfied(data))
				{
					Unlock();
					Reset(ref data);
				}
				else
				{
					Reset(ref data);
				}
			}
			else
			{
				Check(ref data);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}

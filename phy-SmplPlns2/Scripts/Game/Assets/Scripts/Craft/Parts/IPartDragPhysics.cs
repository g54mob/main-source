namespace Assets.Scripts.Craft.Parts
{
	public interface IPartDragPhysics
	{
		void FixedUpdate();

		void Update(float estimateOfUnderwaterPercent);
	}
}

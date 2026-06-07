namespace GameCreator.Runtime.Characters.IK
{
	public abstract class TRigAnimatorIK : TRig
	{
		public sealed override void OnUpdate(Character character)
		{
			DoUpdate(character);
		}
	}
}

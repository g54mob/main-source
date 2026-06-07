namespace Assets.Scripts.GameLoop
{
	public interface IUpdateGroup
	{
		void BeginUpdate(UpdateGroupDebugCallback debugCallback);

		void EndUpdate();
	}
}

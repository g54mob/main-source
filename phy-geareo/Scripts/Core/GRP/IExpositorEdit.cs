namespace GRP
{
	public interface IExpositorEdit
	{
		void OnExpositorEditStart();

		UndoStep OnExpositorEditEnd();
	}
}

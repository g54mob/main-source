using Rhizomatic.Reactive;

namespace GRP
{
	public class ToolGridControl
	{
		public ToolViewable tool;

		public Project project;

		public State<string> gridField;

		public State<float> source;

		public float[] gridValues;

		public bool noFraction;

		private UndoSnapshot snapshot;

		public ToolGridControl(ToolViewable tool, State<string> gridField, State<float> source, params float[] gridValues)
		{
		}

		private void SetGrid(UndoSnapshot snapshot, float value)
		{
		}

		public void UpdateText()
		{
		}

		[CrewMethod]
		public void Next()
		{
		}

		[CrewMethod]
		public void Previous()
		{
		}

		public void OnStartEdit(string value)
		{
		}

		public void OnEndEdit(string value)
		{
		}

		public static (int, int) ToFraction(float value, int maxDecimals = 6)
		{
			return default((int, int));
		}

		private static int GCD(int a, int b)
		{
			return 0;
		}
	}
}

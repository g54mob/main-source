using UnityEngine;

namespace Mystery.Graphing
{
	public class StringGraphConsole : SingleGraphConsole
	{
		private int colorIndex;

		private Color nextColor = DebugGraph.DefaultBlue;

		private bool firstPush = true;

		private string previous = string.Empty;

		public override bool HasYAxis => false;

		public StringGraphConsole(string name, StringLinearPlottableGraph graph)
			: base(name, graph)
		{
		}

		public void Push(float time, string value)
		{
			if (value == previous || firstPush)
			{
				firstPush = false;
			}
			else
			{
				colorIndex++;
				if (colorIndex == 2)
				{
					colorIndex = 0;
				}
				switch (colorIndex)
				{
				case 0:
					nextColor = DebugGraph.DefaultBlue;
					break;
				case 1:
					nextColor = DebugGraph.DefaultGreen;
					break;
				}
			}
			((StringLinearPlottableGraph)base.Graph).AddPoint(time, value, nextColor);
			previous = value;
		}

		public void Push(float time, string value, Color color)
		{
			((StringLinearPlottableGraph)base.Graph).AddPoint(time, value, color);
		}
	}
}

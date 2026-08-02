using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class LapCounter : MonoBehaviour
	{
		private int currentLap;

		public TextMesh text;

		public void CountLap()
		{
			currentLap++;
			text.text = "LAP " + currentLap;
		}
	}
}

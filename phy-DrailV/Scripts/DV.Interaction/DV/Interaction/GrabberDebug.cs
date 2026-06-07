using UnityEngine;
using UnityEngine.UI;

namespace DV.Interaction
{
	public class GrabberDebug : MonoBehaviour
	{
		public Grabber grabber;

		public Text text;

		private void Update()
		{
			text.text = grabber.GetState();
		}
	}
}

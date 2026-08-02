using UnityEngine;
using UnityEngine.UI;

namespace Polarith.AI.Examples
{
	[AddComponentMenu("Polarith AI » Move » Package/Frames Per Second")]
	public sealed class FramesPerSecond : MonoBehaviour
	{
		[Tooltip("A custom Text object that can be assigned to display the frames per second instead of rendering them via OnGui.")]
		public Text DisplayText;

		[Tooltip("Sets the font color.")]
		public Color fontColor = Color.white;

		private Rect position = new Rect(0f, 0f, 100f, 20f);

		private string framerateStr;

		private float deltaTime;

		private void Start()
		{
			Object.DontDestroyOnLoad(this);
			position.x = (float)Screen.width - position.width - 10f;
			position.y = 10f;
		}

		private void Update()
		{
			deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		}

		private void OnGUI()
		{
			float num = 1f / deltaTime;
			framerateStr = $"{num:f1}";
			if (DisplayText == null)
			{
				GUI.contentColor = fontColor;
				GUI.Label(position, $"<b><size=16>FPS: {framerateStr}</size></b>");
			}
			else
			{
				DisplayText.text = "FPS: " + framerateStr + " ";
			}
		}
	}
}

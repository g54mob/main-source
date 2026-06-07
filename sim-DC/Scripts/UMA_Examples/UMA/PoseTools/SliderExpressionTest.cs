using UnityEngine;

namespace UMA.PoseTools
{
	public class SliderExpressionTest : MonoBehaviour
	{
		public Camera cam;

		private GameObject head;

		private UMADynamicAvatar umaAvatar;

		private UMAExpressionPlayer player;

		public UMAExpressionSet expressionSet;

		private bool initialized;

		private bool setValues;

		public int xPos;

		public int yPos;

		public int uiWidth;

		public Vector2 scrollPosition;

		public GUIStyle labelStyle;

		private float[] guiValues;

		public void characterCreated(UMAData umaCreated)
		{
		}

		private void MoveCamera()
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		public void OnGUI()
		{
		}

		public float TargetSlider(float sliderValue, float sliderMaxValue, string labelText)
		{
			return 0f;
		}
	}
}

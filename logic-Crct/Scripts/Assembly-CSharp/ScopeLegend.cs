using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScopeLegend : MonoBehaviour
{
	public struct ScopeData
	{
		public float time;

		public float val;

		public ScopeData(float time, float v)
		{
			this.time = 0f;
			val = 0f;
		}
	}

	[Header("UI Components")]
	public Text refText;

	public Image currentImage;

	public Image voltageImage;

	public BaseComponent comp;

	public Color currentColor;

	public Color voltageColor;

	public List<ScopeData> currentData;

	public List<ScopeData> voltageData;

	public void Create(BaseComponent c, Color cCol, Color vCol)
	{
	}

	private void Update()
	{
	}
}

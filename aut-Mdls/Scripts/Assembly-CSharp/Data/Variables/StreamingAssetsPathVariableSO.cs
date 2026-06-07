using System.IO;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/StreamingAssetsPathVariableSO", fileName = "StreamingAssetsPathVariableSO", order = 0)]
	public class StreamingAssetsPathVariableSO : StringVariableSO
	{
		protected override void OnDisable()
		{
			SetValueToDefault();
		}

		protected override void OnEnable()
		{
			SetValueToDefault();
		}

		private void SetValueToDefault()
		{
			string value = Path.Combine(Application.streamingAssetsPath, _defaultValue);
			SetValue(value);
		}
	}
}

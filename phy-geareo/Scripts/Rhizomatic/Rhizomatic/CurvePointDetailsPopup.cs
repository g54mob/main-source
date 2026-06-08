using Rhizomatic.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class CurvePointDetailsPopup : MonoBehaviour
	{
		public CurveFieldPopup popup;

		public Button deleteKey;

		public NumberField timeField;

		public NumberField valueField;

		public ToggleAdapter inWeighted;

		public ToggleAdapter outWeighted;

		public ToggleAdapter inLinear;

		public ToggleAdapter outLinear;

		public ToggleAdapter auto;

		private CurvePoint point;

		private BackHandlerItem backItem;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Open(CurvePoint point)
		{
		}

		public void Close()
		{
		}

		public void DeleteKey()
		{
		}

		public void SetTime()
		{
		}

		public void SetValue()
		{
		}
	}
}

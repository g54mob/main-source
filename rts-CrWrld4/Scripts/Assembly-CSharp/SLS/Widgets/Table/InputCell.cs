using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SLS.Widgets.Table
{
	public class InputCell : MonoBehaviour
	{
		private bool isTryingDisable;

		private Cell cell;

		public Table table { get; private set; }

		public InputField inputField { get; private set; }

		public RectTransform rectTransform { get; private set; }

		public bool Initialize(Table table, RectTransform rt, InputField inputField)
		{
			return false;
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnEndEdit(string s)
		{
		}

		public void SetFocus(Cell c)
		{
		}

		public void RemoveFocus(bool withRefocus = false)
		{
		}

		private IEnumerator SelectLater()
		{
			return null;
		}

		private IEnumerator DeactivateLater()
		{
			return null;
		}
	}
}

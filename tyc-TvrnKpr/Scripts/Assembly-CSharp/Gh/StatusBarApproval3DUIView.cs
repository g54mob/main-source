using System;
using I18n;
using UnityEngine;

namespace Gh
{
	public class StatusBarApproval3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _approvalValueText;

		private int _currentValue;

		protected void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnUpdateTick(object sender, EventArgs e)
		{
		}
	}
}

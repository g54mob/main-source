using System.Collections.Generic;
using ScheduleOne.Management;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI.Management
{
	public class StringFieldUI : MonoBehaviour
	{
		[Header("References")]
		public TextMeshProUGUI FieldLabel;

		public TMP_InputField InputField;

		public List<StringField> Fields { get; protected set; }

		public void Bind(List<StringField> field)
		{
		}

		private void Refresh(string newVal)
		{
		}

		private bool AreFieldsUniform()
		{
			return false;
		}

		public void ValueChanged(string value)
		{
		}
	}
}

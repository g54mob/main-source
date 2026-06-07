using System.Reflection;
using UnityEngine;

namespace DV.UIFramework
{
	public class NullReferenceError
	{
		public FieldInfo FieldInfo { get; set; }

		public GameObject ErrorGameObject { get; set; }

		public Component SourceComponent { get; set; }

		private string FullName
		{
			get
			{
				Transform parent = ErrorGameObject.transform.parent;
				string text = ErrorGameObject.name;
				while (parent != null)
				{
					text = parent.gameObject.name + " / " + text;
					parent = parent.transform.parent;
				}
				return text;
			}
		}

		public NullReferenceError(FieldInfo fieldInfo, Component component)
		{
			FieldInfo = fieldInfo;
			SourceComponent = component;
			ErrorGameObject = ((component != null) ? component.gameObject : null);
		}

		public override string ToString()
		{
			return string.Format("Unassigned '<b>" + FieldInfo.Name + "</b>' in '<b>" + SourceComponent.GetType().Name + "</b>' on '" + FullName + "'");
		}
	}
}

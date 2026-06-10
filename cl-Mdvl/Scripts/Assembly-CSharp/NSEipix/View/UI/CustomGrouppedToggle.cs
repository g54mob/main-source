using System;
using UnityEngine;
using UnityEngine.UI;

namespace NSEipix.View.UI
{
	public class CustomGrouppedToggle : CustomToggle
	{
		protected override void Start()
		{
			if (base.group == null)
			{
				try
				{
					base.group = base.transform.GetComponentInParent(typeof(ToggleGroup)) as ToggleGroup;
				}
				catch (Exception)
				{
					Debug.Log("There is no component of type ToggleGroup in any of my parents");
					throw;
				}
			}
			base.Start();
		}
	}
}

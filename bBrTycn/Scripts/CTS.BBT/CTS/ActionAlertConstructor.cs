using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	[Obsolete("Doesn't work anymore")]
	public class ActionAlertConstructor : ActionConstructor<CustomerActionAlert>
	{
		[SerializeField]
		private SoftReference<Crime> _crimeReference;

		protected override CustomerActionAlert ConstructAction()
		{
			return null;
		}
	}
}

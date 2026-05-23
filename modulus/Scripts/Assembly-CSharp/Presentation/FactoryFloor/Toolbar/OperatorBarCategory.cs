using System;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	[Serializable]
	public struct OperatorBarCategory
	{
		public List<operatorBarButtonActivator> OperatorBarButtonActivators;

		public Color CategoryColor;
	}
}

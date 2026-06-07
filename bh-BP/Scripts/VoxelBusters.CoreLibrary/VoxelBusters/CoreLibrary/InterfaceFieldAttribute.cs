using System;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class InterfaceFieldAttribute : PropertyAttribute
	{
		public Type InterfaceType { get; private set; }

		public InterfaceFieldAttribute(Type interfaceType)
		{
		}
	}
}

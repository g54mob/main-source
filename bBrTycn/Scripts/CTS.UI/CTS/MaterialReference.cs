using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class MaterialReference : CTSBehaviour
	{
		public Material MaterialInstance { get; protected set; }
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rhizomatic
{
	public class TheCamera : MonoBehaviour
	{
		public UhCamera defaultCamera;

		public List<UhCamera> cameras;

		public UhCamera activeCamera { get; private set; }

		public static TheCamera instance { get; private set; }

		public static Camera current => null;

		public event Action<UhCamera> onActivate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void Activate(UhCamera camera)
		{
		}

		public void Deactivate(UhCamera camera)
		{
		}
	}
}

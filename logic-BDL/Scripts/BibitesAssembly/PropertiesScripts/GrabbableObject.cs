using System.Collections.Generic;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using UnityEngine.Events;

namespace PropertiesScripts
{
	public class GrabbableObject : MonoBehaviour
	{
		private List<BibiteMouth> Grabbers = new List<BibiteMouth>();

		public UnityEvent<bool> onGrab = new UnityEvent<bool>();

		public Rigidbody2D TryGrab(BibiteMouth grabber)
		{
			foreach (BibiteMouth grabber2 in Grabbers)
			{
				if (grabber2.Equals(grabber))
				{
					return GetComponent<Rigidbody2D>();
				}
			}
			Grabbers.Add(grabber);
			onGrab.Invoke(arg0: true);
			return GetComponent<Rigidbody2D>();
		}

		public void Release(BibiteMouth grabber)
		{
			Grabbers.Remove(grabber);
			onGrab.Invoke(arg0: false);
		}

		public void FreeFromAll()
		{
			onGrab.Invoke(arg0: false);
			foreach (BibiteMouth grabber in Grabbers)
			{
				grabber.ReleaseGrabbed(base.gameObject);
			}
		}

		private void OnDestroy()
		{
			FreeFromAll();
		}
	}
}

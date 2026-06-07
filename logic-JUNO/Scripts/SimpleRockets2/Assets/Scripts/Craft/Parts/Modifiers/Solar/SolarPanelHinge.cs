using System.Collections.Generic;
using ModApi;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Solar
{
	public class SolarPanelHinge : MonoBehaviour
	{
		private MeshRenderer _panelRenderer;

		private bool _childrenOpened;

		public float ClosedRotation { get; set; }

		public float DeploySpeed { get; set; } = 1f;

		public bool HasCover { get; set; } = true;

		public bool IsBaseHinge { get; set; }

		public bool IsClosed { get; private set; }

		public bool IsMainHinge { get; set; }

		public SolarPanelHinge MainHingeChild { get; set; }

		public float OpenRotation { get; set; }

		public bool RendererEnabled
		{
			get
			{
				return (_panelRenderer?.enabled).Value;
			}
			set
			{
				if (_panelRenderer != null)
				{
					_panelRenderer.enabled = value;
				}
			}
		}

		public bool RotatedLastFrame { get; private set; }

		public bool ShouldBeOpen { get; set; }

		public List<SolarPanelHinge> SideHinges { get; set; } = new List<SolarPanelHinge>();

		public bool Wait4Papa { get; set; }

		public bool AreChildrenFullyClosed()
		{
			if (!AreSidesFullyClosed())
			{
				return false;
			}
			if (MainHingeChild != null)
			{
				return MainHingeChild.AreChildrenFullyClosed();
			}
			return true;
		}

		public bool AreSidesFullyClosed()
		{
			if (SideHinges.Count > 0)
			{
				for (int i = 0; i < SideHinges.Count; i++)
				{
					if (!SideHinges[i].IsClosed)
					{
						return false;
					}
				}
			}
			return true;
		}

		public void ArrayInitialize()
		{
			_panelRenderer = base.transform.GetChild(0).GetComponent<MeshRenderer>();
			MainHingeChild?.ArrayInitialize();
			foreach (SolarPanelHinge sideHinge in SideHinges)
			{
				sideHinge.ArrayInitialize();
			}
		}

		public void ArrayUpdate(float deltaTime)
		{
			RotatedLastFrame = false;
			if (ShouldBeOpen)
			{
				Quaternion openRotation = GetOpenRotation();
				base.transform.localRotation = Quaternion.RotateTowards(base.transform.localRotation, openRotation, deltaTime * 60f * DeploySpeed);
				IsClosed = false;
				if (!_childrenOpened && Utilities.CompareQuaternions(base.transform.localRotation, openRotation, 1E-05f))
				{
					OpenChildren();
				}
				else if (!_childrenOpened)
				{
					RotatedLastFrame = true;
				}
				return;
			}
			if (_childrenOpened)
			{
				CloseChildren();
			}
			if (AreChildrenFullyClosed() && !Wait4Papa)
			{
				Quaternion closedRotation = GetClosedRotation();
				base.transform.localRotation = Quaternion.RotateTowards(base.transform.localRotation, closedRotation, deltaTime * 60f * DeploySpeed);
				if (!IsClosed && Utilities.CompareQuaternions(base.transform.localRotation, closedRotation, 1E-05f))
				{
					IsClosed = true;
				}
				else if (!IsClosed)
				{
					RotatedLastFrame = true;
				}
				if (MainHingeChild != null)
				{
					MainHingeChild.Wait4Papa = false;
				}
			}
			else if (MainHingeChild != null)
			{
				MainHingeChild.Wait4Papa = true;
			}
		}

		public Quaternion GetClosedRotation()
		{
			return Quaternion.Euler(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, ClosedRotation);
		}

		public Quaternion GetOpenRotation()
		{
			return Quaternion.Euler(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, OpenRotation);
		}

		public void SnapRotation(float openPercentage)
		{
			openPercentage = Mathf.Clamp01(openPercentage);
			Quaternion openRotation = GetOpenRotation();
			Quaternion closedRotation = GetClosedRotation();
			base.transform.localRotation = Quaternion.RotateTowards(closedRotation, openRotation, Mathf.Abs(ClosedRotation - OpenRotation) * openPercentage);
			if (Mathf.Approximately(openPercentage, 0f))
			{
				IsClosed = true;
				if (_panelRenderer.enabled && !IsBaseHinge && HasCover)
				{
					_panelRenderer.enabled = false;
				}
			}
			else
			{
				IsClosed = false;
				if (!_panelRenderer.enabled)
				{
					_panelRenderer.enabled = true;
				}
			}
		}

		private void CloseChildren()
		{
			for (int i = 0; i < SideHinges.Count; i++)
			{
				SideHinges[i].ShouldBeOpen = false;
			}
			_childrenOpened = false;
		}

		private void OpenChildren()
		{
			for (int i = 0; i < SideHinges.Count; i++)
			{
				SideHinges[i].ShouldBeOpen = true;
			}
			_childrenOpened = true;
		}
	}
}

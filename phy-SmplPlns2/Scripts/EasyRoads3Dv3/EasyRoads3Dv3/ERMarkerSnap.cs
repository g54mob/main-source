using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[ExecuteInEditMode]
	public class ERMarkerSnap : MonoBehaviour
	{
		private ERModularBase vssss;

		private ERModularRoad wssst;

		private int xssss = -1;

		private Vector3 yssst;

		private float Assss = 0f;

		private float _0ssst = 0f;

		private float _1ssss = 0f;

		private float _2ssst = 0f;

		private float _3ssss = 0f;

		private float _4ssst = 0f;

		private float ttsss = 0f;

		private float utsst = 0f;

		private Vector3 vtsss;

		private bool wtsst = false;

		private List<ERMarkerSnap> xtsss = new List<ERMarkerSnap>();

		[Tooltip("Disable Terrain Deformation, this is typically checked for top level Snap Markers on bridge prefabs.")]
		public bool terrainDeformationControl = false;

		private bool ytsst = true;

		[Tooltip("Sets the attached marker Indent distance to this value, this can be used for automated additional terrain deformation control.")]
		public float markerIndent = 0f;

		[Tooltip("Sets the attached marker Surrounding distance to this value, this can be used for automated additional terrain deformation control.")]
		public float markerSurrounding = 0f;

		public void OnDrawGizmos()
		{
			if (base.transform.position != vtsss)
			{
				vtsss = base.transform.position;
				if (wssst != null && xssss < wssst.markersExt.Count)
				{
					wssst.markersExt[xssss].position = vtsss;
					if (wtsst)
					{
						foreach (ERMarkerSnap item in xtsss)
						{
							if (item.wssst == wssst && item.xssss < wssst.markersExt.Count)
							{
								item.wssst.markersExt[item.xssss].position = item.transform.position;
							}
						}
						wssst.ODDDQDQOOD(ignorePrefabAlignment: false, forceAutoRotate: false);
					}
				}
			}
			if (vssss == null)
			{
				vssss = Object.FindObjectOfType<ERModularBase>();
				return;
			}
			Gizmos.color = new Color(0.25f, 0.78f, 0.26f, 1f);
			float radius = 0.75f;
			if (vssss.OOOCDDCQCD != null && vssss.OODOOQQDQD >= 0 && vssss.OOOCDDCQCD.markersExt.Count > vssss.OODOOQQDQD)
			{
				Vector3 position = vssss.OOOCDDCQCD.markersExt[vssss.OODOOQQDQD].position;
				if (!(yssst != position))
				{
					Gizmos.DrawSphere(base.transform.position, radius);
					return;
				}
				yssst = position;
				float num = Vector3.Distance(base.transform.position, position);
				if (num < 3f && (wssst == null || (vssss.OOOCDDCQCD == wssst && vssss.OODOOQQDQD == xssss)))
				{
					Debug.Log(wssst?.ToString() + "  " + xssss);
					if (wssst != vssss.OOOCDDCQCD && xssss != vssss.OODOOQQDQD)
					{
						radius = 1f;
						wssst = vssss.OOOCDDCQCD;
						xssss = vssss.OODOOQQDQD;
						if (markerIndent != 0f)
						{
							Assss = wssst.markersExt[xssss].leftIndent;
							_0ssst = wssst.markersExt[xssss].rightIndent;
							wssst.markersExt[xssss].leftIndent = (wssst.markersExt[xssss].rightIndent = markerIndent);
						}
						if (markerSurrounding != 0f)
						{
							_1ssss = wssst.markersExt[xssss].leftSurrounding;
							_2ssst = wssst.markersExt[xssss].rightSurrounding;
							wssst.markersExt[xssss].leftSurrounding = (wssst.markersExt[xssss].rightSurrounding = markerSurrounding);
						}
						ERMarkerSnap eRMarkerSnap = null;
						int num2 = ussst(wssst, xssss, ref eRMarkerSnap);
						if (num2 != 0)
						{
							if (num2 < 0)
							{
								wssst.markersExt[xssss].controlType = 2;
								if (terrainDeformationControl)
								{
									wssst.markersExt[xssss].bridgeObject = true;
									wssst.markersExt[xssss].snappedMarker = true;
									_3ssss = wssst.markersExt[xssss].randomMinYPosition;
									_4ssst = wssst.markersExt[xssss].randomMaxYPosition;
									ttsss = wssst.markersExt[xssss].randomMinRotation;
									utsst = wssst.markersExt[xssss].randomMaxRotation;
									wssst.markersExt[xssss].randomMinYPosition = 0f;
									wssst.markersExt[xssss].randomMaxYPosition = 0f;
									wssst.markersExt[xssss].randomMinRotation = 0f;
									wssst.markersExt[xssss].randomMaxRotation = 0f;
								}
							}
							else
							{
								eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].controlType = 2;
								if (eRMarkerSnap.terrainDeformationControl)
								{
									eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].bridgeObject = true;
									eRMarkerSnap.wssst.markersExt[xssss].snappedMarker = true;
									eRMarkerSnap._3ssss = eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMinYPosition;
									eRMarkerSnap._4ssst = eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMaxYPosition;
									eRMarkerSnap.ttsss = eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMinRotation;
									eRMarkerSnap.utsst = eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMaxRotation;
									eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMinYPosition = 0f;
									eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMaxYPosition = 0f;
									eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMinRotation = 0f;
									eRMarkerSnap.wssst.markersExt[eRMarkerSnap.xssss].randomMaxRotation = 0f;
								}
							}
						}
					}
					vssss.OOOCDDCQCD.markersExt[vssss.OODOOQQDQD].position = base.transform.position;
				}
				else if ((double)num > 3.5 && vssss.OOOCDDCQCD == wssst && vssss.OODOOQQDQD == xssss)
				{
					ERMarkerSnap eRMarkerSnap2 = null;
					int num3 = ussst(wssst, xssss, ref eRMarkerSnap2);
					if (num3 != 0 && eRMarkerSnap2 != null)
					{
						if (num3 < 0)
						{
							wssst.markersExt[xssss].controlType = 0;
							if (terrainDeformationControl)
							{
								wssst.markersExt[xssss].bridgeObject = false;
								wssst.markersExt[xssss].snappedMarker = false;
								wssst.markersExt[xssss].randomMinYPosition = _3ssss;
								wssst.markersExt[xssss].randomMaxYPosition = _4ssst;
								wssst.markersExt[xssss].randomMinRotation = ttsss;
								wssst.markersExt[xssss].randomMaxRotation = utsst;
							}
						}
						else
						{
							eRMarkerSnap2.wssst.markersExt[eRMarkerSnap2.xssss].controlType = 0;
							if (eRMarkerSnap2.terrainDeformationControl)
							{
								eRMarkerSnap2.wssst.markersExt[eRMarkerSnap2.xssss].bridgeObject = false;
								eRMarkerSnap2.wssst.markersExt[xssss].snappedMarker = false;
								eRMarkerSnap2.wssst.markersExt[eRMarkerSnap2.xssss].randomMinYPosition = eRMarkerSnap2._3ssss;
								eRMarkerSnap2.wssst.markersExt[eRMarkerSnap2.xssss].randomMaxYPosition = eRMarkerSnap2._4ssst;
								eRMarkerSnap2.wssst.markersExt[eRMarkerSnap2.xssss].randomMinRotation = eRMarkerSnap2.ttsss;
								eRMarkerSnap2.wssst.markersExt[eRMarkerSnap2.xssss].randomMaxRotation = eRMarkerSnap2.utsst;
							}
						}
					}
					if (Assss != 0f && markerIndent != 0f)
					{
						wssst.markersExt[xssss].leftIndent = Assss;
					}
					if (_0ssst != 0f && markerIndent != 0f)
					{
						wssst.markersExt[xssss].rightIndent = _0ssst;
					}
					if (_1ssss != 0f && markerSurrounding != 0f)
					{
						wssst.markersExt[xssss].leftSurrounding = _1ssss;
					}
					if (_2ssst != 0f && markerSurrounding != 0f)
					{
						wssst.markersExt[xssss].rightSurrounding = _2ssst;
					}
					wssst = null;
					xssss = -1;
				}
			}
			Gizmos.DrawSphere(base.transform.position, radius);
		}

		private int ussst(ERModularRoad tssss, int ussss, ref ERMarkerSnap vssss)
		{
			ERMarkerSnap[] array = null;
			if (base.transform.parent != null)
			{
				array = base.transform.parent.GetComponentsInChildren<ERMarkerSnap>();
				List<ERModularRoad> list = new List<ERModularRoad>();
				ERMarkerSnap[] array2 = array;
				foreach (ERMarkerSnap eRMarkerSnap in array2)
				{
					if (eRMarkerSnap != this)
					{
						if (eRMarkerSnap.wssst != null && !list.Contains(eRMarkerSnap.wssst))
						{
							list.Add(eRMarkerSnap.wssst);
							eRMarkerSnap.wtsst = true;
							eRMarkerSnap.xtsss = new List<ERMarkerSnap>(array);
						}
						else
						{
							eRMarkerSnap.wtsst = false;
							eRMarkerSnap.xtsss.Clear();
						}
						if (eRMarkerSnap.wssst == tssss && Mathf.Abs(ussss - eRMarkerSnap.xssss) <= 1)
						{
							vssss = eRMarkerSnap;
							return ussss - eRMarkerSnap.xssss;
						}
					}
				}
				return 0;
			}
			return 0;
		}
	}
}

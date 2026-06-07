using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using ModApi;
using ModApi.Audio;
using ModApi.Craft.Parts;
using ModApi.Design;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class MovePartToolHelper
	{
		private AttachPointScript _closestAttachPoint;

		private List<AttachPointScript> _highlightedAttachpoints = new List<AttachPointScript>();

		private PartSelection _partSelection;

		private MovePartTool _tool;

		public bool SelectedPartsColliding { get; private set; }

		private static bool EnableAutoRotation => Game.Instance.Settings.Game.Designer.EnableAutoRotation;

		public MovePartToolHelper(MovePartTool tool)
		{
			_tool = tool;
		}

		public static int DetectAttachPointConnectionsAndConnect(ICollection<AttachPointScript> attachPoints)
		{
			int num = 0;
			bool flag = false;
			Dictionary<IPartScript, bool> dictionary = new Dictionary<IPartScript, bool>();
			foreach (AttachPointScript attachPoint in attachPoints)
			{
				if (!attachPoint.AttachPoint.IsAvailable || attachPoint.AttachPoint.IsSurfaceAttachPoint)
				{
					continue;
				}
				PartScript partScript = attachPoint.PartScript as PartScript;
				_ = attachPoint.WorldNormal;
				Vector3 position = attachPoint.transform.position;
				int num2 = 1 << attachPoint.ConnectToLayer;
				if (!attachPoint.AttachPoint.IgnoreSurfaces)
				{
					num2 |= 0x2000;
				}
				Collider[] array = Physics.OverlapSphere(attachPoint.transform.position, 1f / 32f, num2);
				AttachPointScript attachPointScript = null;
				Collider[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					AttachPointScript component = array2[i].GetComponent<AttachPointScript>();
					if (component != null && !component.AttachPoint.IsSurfaceAttachPoint && component.AttachPoint.IsAvailable && AttachPointsCompatible(attachPoint, component) && CheckAttachPointNormalCompatibility(attachPoint, component.WorldNormal) && (component.transform.position - position).magnitude < 1f / 32f)
					{
						if (attachPoint.PartScript != component.PartScript)
						{
							attachPointScript = component;
						}
						break;
					}
				}
				if (attachPointScript == null && !attachPoint.AttachPoint.IgnoreSurfaces)
				{
					array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						AttachPointScript[] components = array2[i].GetComponents<AttachPointScript>();
						foreach (AttachPointScript attachPointScript2 in components)
						{
							if (attachPointScript2.AttachPoint.IsSurfaceAttachPoint && attachPointScript2.AttachPoint.IsAvailable && AttachPointsCompatible(attachPoint, attachPointScript2))
							{
								if (attachPoint.PartScript != attachPointScript2.PartScript)
								{
									attachPointScript = attachPointScript2;
								}
								break;
							}
						}
					}
				}
				if (!(attachPointScript != null) || !attachPointScript.AttachPoint.IsAvailable)
				{
					continue;
				}
				bool flag2 = true;
				if (partScript.SymmetrySlice != null)
				{
					PartScript partScript2 = attachPointScript.PartScript as PartScript;
					flag2 = partScript2.SymmetrySlice == partScript.SymmetrySlice || (partScript.Data == partScript.SymmetrySlice.SliceRootPart && partScript2 == partScript.SymmetrySlice.SymmetryGroup.RootPart);
				}
				if (flag2)
				{
					PartScript.ConnectParts(attachPoint, attachPointScript, processingSymmetry: false);
					dictionary[attachPoint.PartScript] = true;
					if (dictionary.ContainsKey(attachPointScript.PartScript))
					{
						dictionary[attachPointScript.PartScript] = dictionary[attachPointScript.PartScript];
					}
					else
					{
						dictionary[attachPointScript.PartScript] = false;
					}
					num++;
					flag = flag || attachPointScript.AttachPoint.RenderQueue == PartMeshRenderQueue.BeforeDepthMask;
				}
			}
			foreach (KeyValuePair<IPartScript, bool> item in dictionary)
			{
				if (item.Value)
				{
					Symmetry.SynchronizePartConnections(item.Key);
				}
				Symmetry.SynchronizePartModifiers(item.Key);
			}
			if (flag)
			{
				foreach (AttachPointScript attachPoint2 in attachPoints)
				{
					attachPoint2.PartScript.Data.Config.RenderQueue = PartMeshRenderQueue.BeforeDepthMask;
				}
			}
			return num;
		}

		public void DragEnd()
		{
			_closestAttachPoint = null;
			_partSelection = null;
			ShowAttachPoints(show: false);
			HighlightAttachPoints((AttachPointScript[])null);
		}

		public void DragPart(Ray screenRay)
		{
			float num = float.MaxValue;
			_ = Vector3.zero;
			AttachPointScript attachPointScript = null;
			AttachPointScript attachPointScript2 = null;
			Vector3 attachmentPosition = Vector3.zero;
			Vector3 vector = Vector3.zero;
			Vector3 closestAttachPointNormal = Vector3.zero;
			string text = null;
			HideSymmetricParts(_partSelection.Parts);
			foreach (AttachPointScript availableAttachPoint in _partSelection.AvailableAttachPoints)
			{
				if (availableAttachPoint == null || !availableAttachPoint.gameObject.activeSelf || !availableAttachPoint.AttachPoint.CanSeek)
				{
					continue;
				}
				if (availableAttachPoint.AttachPoint.CanSeek && availableAttachPoint.AttachPoint.IsSurfaceAttachPoint)
				{
					Debug.Log("Surface attach point that can seek....: " + availableAttachPoint.PartScript.Data.Name);
				}
				List<RaycastHit> hitResults = GetHitResults(screenRay, availableAttachPoint);
				List<AttachPointScript> list = new List<AttachPointScript>();
				bool flag = false;
				foreach (RaycastHit item in hitResults)
				{
					list.Clear();
					if (item.collider.GetComponent<DepthMaskScript>() != null)
					{
						PartScript componentInParent = item.collider.GetComponentInParent<PartScript>();
						if (!_partSelection.Parts.Contains(componentInParent))
						{
							flag = true;
						}
						continue;
					}
					item.collider.GetComponents(list);
					foreach (AttachPointScript item2 in list)
					{
						if (!(item2 != null) || !item2.AttachPoint.IsAvailable || !AttachPointsCompatible(availableAttachPoint, item2) || (item2.AttachPoint.RequiresPhysicsJoint && availableAttachPoint.AttachPoint.RequiresPhysicsJoint) || (flag && item2.PartScript.Data.Config.RenderQueue != PartMeshRenderQueue.BeforeDepthMask))
						{
							continue;
						}
						Vector3 zero = Vector3.zero;
						Vector3 zero2 = Vector3.zero;
						if (!item2.AttachPoint.IsSurfaceAttachPoint)
						{
							zero = item2.transform.position;
							zero2 = item2.WorldNormal;
						}
						else
						{
							zero = item.point;
							zero2 = item.normal;
						}
						if (!CheckAttachPointNormalCompatibility(availableAttachPoint, zero2))
						{
							continue;
						}
						if (item.distance < num)
						{
							text = null;
							num = item.distance;
							attachPointScript = item2;
							attachPointScript2 = availableAttachPoint;
							vector = item.point;
							bool flag2 = false;
							float snappedAngle = 0f;
							if (attachPointScript2.AttachPoint.AllowRotation && item2.AttachPoint.IsSurfaceAttachPoint && EnableAutoRotation)
							{
								flag2 = HandleSnapping(ref attachmentPosition, ref closestAttachPointNormal, item, item2, zero, zero2, out snappedAngle);
							}
							if (!flag2)
							{
								attachmentPosition = zero;
								closestAttachPointNormal = zero2;
							}
							else
							{
								text = string.Format("Angle: {0:n0}{1}", snappedAngle, "°");
							}
						}
						break;
					}
				}
			}
			bool flag3 = false;
			bool flag4 = false;
			if (attachPointScript != null)
			{
				IPartScript partScript = attachPointScript.PartScript;
				if (!partScript.Data.SymmetryId.HasValue || partScript.Data.SymmetryId != attachPointScript2.PartScript.Data.SymmetryId)
				{
					if (attachPointScript2.AttachPoint.AllowRotation && EnableAutoRotation)
					{
						MatchTargetRotation(attachPointScript2, attachmentPosition, closestAttachPointNormal, attachPointScript);
						flag4 = true;
					}
					else
					{
						Vector3 vector2 = attachmentPosition - attachPointScript2.transform.position;
						if (!AutoRotateFuselage(attachPointScript, attachPointScript2, attachmentPosition))
						{
							_partSelection.ContainerParent.position += vector2;
						}
						if (!attachPointScript.AttachPoint.IsSurfaceAttachPoint)
						{
							flag4 = true;
						}
						else if ((attachmentPosition - vector).magnitude < 0.1f)
						{
							flag4 = true;
						}
					}
					if (_closestAttachPoint != attachPointScript)
					{
						_tool.Designer.PlaySound(AudioLibrary.Design.SuggestConnection);
					}
					PartScript partScript2 = attachPointScript2.PartScript as PartScript;
					if (partScript2.Data.SymmetryMode != SymmetryMode.None || partScript2.Data.SymmetryId.HasValue || attachPointScript.PartScript.Data.SymmetryId.HasValue)
					{
						Symmetry.UpdateSymmetry(_partSelection.Parts, partScript2, attachPointScript.AttachPoint);
					}
					flag3 = _tool.PartCollisionsEnabled && _partSelection.DetectCollisions();
				}
			}
			_closestAttachPoint = attachPointScript;
			if (flag4)
			{
				HighlightAttachPoints(attachPointScript, attachPointScript2);
			}
			else
			{
				HighlightAttachPoints((AttachPointScript[])null);
			}
			if (flag3 != SelectedPartsColliding)
			{
				SelectedPartsColliding = flag3;
			}
			foreach (IPartScript part in _partSelection.Parts)
			{
				part.PartMaterialScript.IsCollidingInDesigner = SelectedPartsColliding;
				part.PartMaterialScript.FoundAttachPoint = flag4;
				foreach (IPartScript item3 in Symmetry.EnumerateSymmetricPartScripts(part))
				{
					item3.PartMaterialScript.IsCollidingInDesigner = SelectedPartsColliding;
				}
			}
			if (text != null)
			{
				_tool.Designer.ShowMessage(text, 2f);
			}
		}

		public void DragStart(PartSelection partSelection)
		{
			_partSelection = partSelection;
			SelectedPartsColliding = false;
			ShowAttachPoints(show: true);
		}

		public void HighlightAttachPoints(params AttachPointScript[] attachPoints)
		{
			foreach (AttachPointScript highlightedAttachpoint in _highlightedAttachpoints)
			{
				highlightedAttachpoint.RestoreColor();
			}
			_highlightedAttachpoints.Clear();
			if (attachPoints != null)
			{
				foreach (AttachPointScript attachPointScript in attachPoints)
				{
					_highlightedAttachpoints.Add(attachPointScript);
					attachPointScript?.SetColor(Color.green);
				}
			}
		}

		public void ShowAttachPoints(bool show)
		{
			if (!Game.Instance.Settings.Game.Designer.ShowAttachPoints)
			{
				return;
			}
			IReadOnlyList<PartData> parts = _tool.Designer.CraftScript.Data.Assembly.Parts;
			if (show && _partSelection != null)
			{
				foreach (PartData item in parts)
				{
					if (!item.PartScript.AttachPointsEnabled)
					{
						continue;
					}
					foreach (AttachPoint attachPoint in item.AttachPoints)
					{
						if (attachPoint.ConnectionType != AttachPointConnectionType.Legacy)
						{
							attachPoint.AttachPointScript.RestoreColor();
							attachPoint.AttachPointScript.Visible = attachPoint.CanReceive && attachPoint.IsAvailable && ((uint)_partSelection.ConnectionMask & (uint)attachPoint.ConnectionType) != 0;
							if (attachPoint.AttachPointScript.Visible)
							{
								attachPoint.AttachPointScript.FlipVisuals = true;
							}
						}
					}
				}
				{
					foreach (AttachPointScript availableAttachPoint in _partSelection.AvailableAttachPoints)
					{
						availableAttachPoint.Visible = availableAttachPoint.AttachPoint.CanSeek && availableAttachPoint.AttachPoint.IsAvailable;
						if (availableAttachPoint.Visible)
						{
							availableAttachPoint.FlipVisuals = false;
						}
					}
					return;
				}
			}
			if (show)
			{
				return;
			}
			foreach (PartData item2 in parts)
			{
				foreach (AttachPoint attachPoint2 in item2.AttachPoints)
				{
					attachPoint2.AttachPointScript.Visible = false;
				}
			}
		}

		public Ray WorldPointToRay(Vector3 position)
		{
			Vector3 position2 = _tool.Designer.DesignerCamera.Transform.position;
			return new Ray(position2, (position - position2).normalized);
		}

		private static bool AttachPointsCompatible(AttachPointScript attachPoint, AttachPointScript targetAttachPoint)
		{
			if (attachPoint.AttachPoint.ConnectionType == targetAttachPoint.AttachPoint.ConnectionType)
			{
				return attachPoint.PartScript.AcceptConnection(attachPoint, targetAttachPoint);
			}
			return false;
		}

		private static bool CheckAttachPointNormalCompatibility(AttachPointScript attachPoint, Vector3 targetNormal)
		{
			if (!Utilities.CompareVector3s(attachPoint.WorldNormal + targetNormal, Vector3.zero, 0.02f))
			{
				if (attachPoint.AttachPoint.AllowRotation && EnableAutoRotation)
				{
					return Vector3.Dot(attachPoint.WorldNormal, -targetNormal) >= -0.5f || !attachPoint.AttachPoint.IgnoreSurfaces || attachPoint.AttachPoint.AllowInvertedConnection;
				}
				return false;
			}
			return true;
		}

		private static void GetForwardAndUpVectorsForRayHit(Vector3 preferredUp, Vector3 preferredForward, Vector3 backupUp, out Vector3 forward, out Vector3 up)
		{
			forward = preferredForward;
			up = preferredUp;
			if (Mathf.Abs(Vector3.Dot(up, forward)) >= 0.9f)
			{
				up = backupUp;
			}
			if (Mathf.Abs(Vector3.Dot(up, forward)) >= 0.9f)
			{
				up = Vector3.forward;
			}
		}

		private static bool GetSurfaceAttachmentPoint(Vector3 initialPos, IPartScript partScript, Vector3 surfaceNormal, out Vector3 point, out Vector3 normal, bool insideOutCast)
		{
			bool result = false;
			point = Vector3.zero;
			normal = Vector3.zero;
			if (partScript != null)
			{
				Ray ray = new Ray(initialPos + surfaceNormal * 1000f, -surfaceNormal);
				if (insideOutCast)
				{
					ray = new Ray(initialPos, surfaceNormal);
				}
				float num = float.MaxValue;
				Collider[] componentsInChildren = partScript.GameObject.GetComponentsInChildren<Collider>();
				int num2 = 0;
				while (componentsInChildren != null && num2 < componentsInChildren.Length)
				{
					Collider collider = componentsInChildren[num2];
					if (collider.gameObject.layer == 13 && collider.Raycast(ray, out var hitInfo, 10000f))
					{
						float num3 = Vector3.Distance(hitInfo.point, initialPos);
						if (num3 < num)
						{
							num = num3;
							point = hitInfo.point;
							normal = hitInfo.normal;
							result = true;
						}
					}
					num2++;
				}
			}
			return result;
		}

		private static bool HandleSnapping(ref Vector3 attachmentPosition, ref Vector3 closestAttachPointNormal, RaycastHit hit, AttachPointScript targetAttachPoint, Vector3 attachPointPosition, Vector3 attachPointNormal, out float snappedAngle)
		{
			bool result = false;
			snappedAngle = 0f;
			float num = Game.Instance.Settings.Game.Designer.AngleSnap;
			float num2 = Game.Instance.Settings.Game.Designer.GridSize;
			if (num > 0f || num2 > 0f)
			{
				Transform transform = targetAttachPoint.PartScript.Transform;
				Vector3 vector = transform.InverseTransformPoint(hit.point);
				Vector3 rhs = transform.InverseTransformDirection(attachPointNormal);
				bool flag = Vector3.Dot(vector, rhs) < 0f;
				if (Mathf.Abs(rhs.y) < 0.7f)
				{
					if (num2 > 0f)
					{
						vector.y = Utilities.SnapToGrid(vector.y, num2);
						attachmentPosition = transform.TransformPoint(vector);
						closestAttachPointNormal = attachPointNormal;
					}
					Vector3 vector2 = new Vector3(vector.x, 0f, vector.z);
					float num3 = Vector3.Angle(Vector3.forward, vector2);
					if (Vector3.Cross(Vector3.forward, vector2).y < 0f)
					{
						num3 = 360f - num3;
					}
					snappedAngle = Utilities.SnapToGrid(num3, num);
					Vector3 vector3 = Quaternion.Euler(0f, snappedAngle, 0f) * Vector3.forward;
					Vector3 position = new Vector3(0f, vector.y, 0f);
					if (!flag)
					{
						position += vector3;
					}
					Vector3 initialPos = transform.TransformPoint(position);
					Vector3 vector4 = transform.TransformDirection(vector3);
					if (!GetSurfaceAttachmentPoint(initialPos, targetAttachPoint.PartScript, vector4, out var point, out var normal, flag))
					{
						point = attachPointPosition;
						normal = attachPointNormal;
					}
					else if (num > 0f && !flag && Vector3.Dot(vector4, normal) >= 0.98f)
					{
						Vector3 direction = transform.InverseTransformDirection(normal);
						normal = vector4;
						if (direction.y != 0f)
						{
							direction.x = 0f;
							direction.z = 0f;
							normal += transform.TransformDirection(direction);
							normal.Normalize();
						}
					}
					attachmentPosition = point;
					closestAttachPointNormal = normal;
					result = true;
				}
			}
			return result;
		}

		private static void HideSymmetricParts(List<IPartScript> partScripts)
		{
			if (partScripts.Count <= 0)
			{
				return;
			}
			ISymmetrySlice symmetrySlice = (partScripts[0] as PartScript).SymmetrySlice;
			if (symmetrySlice == null || partScripts.Contains(symmetrySlice.SymmetryGroup.RootPart))
			{
				return;
			}
			foreach (ISymmetrySlice slice in symmetrySlice.SymmetryGroup.Slices)
			{
				if (slice == symmetrySlice)
				{
					continue;
				}
				foreach (IPartScript partScript in partScripts)
				{
					if (partScript.Data.SymmetryId.HasValue)
					{
						PartData part = slice.GetPart(partScript.Data.SymmetryId.Value);
						if (part != null)
						{
							part.PartScript.Transform.gameObject.SetActive(value: false);
						}
					}
				}
			}
		}

		private bool AutoRotateFuselage(AttachPointScript closestAttachPoint, AttachPointScript selectedAttachPoint, Vector3 attachmentPosition)
		{
			bool result = false;
			if (selectedAttachPoint.PartScript.GetModifier<FuselageScript>() != null)
			{
				Vector3 vector = closestAttachPoint.transform.InverseTransformDirection(selectedAttachPoint.transform.up);
				float num = Mathf.Atan2(vector.y, vector.x) * 57.29578f;
				float num2 = num;
				if (Mathf.Abs(num) <= 45f)
				{
					num2 = 0f;
				}
				else if (num >= 45f && num <= 135f)
				{
					num2 = 90f;
				}
				else if (num >= 135f)
				{
					num2 = 180f;
				}
				else if (num <= -45f && num >= -135f)
				{
					num2 = -90f;
				}
				else if (num < -135f)
				{
					num2 = -180f;
				}
				float num3 = num2 - num;
				if (Mathf.Abs(num3) > 0.5f)
				{
					GameObject gameObject = new GameObject("AttachPointRotation");
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.SetPositionAndRotation(selectedAttachPoint.transform.position, selectedAttachPoint.transform.rotation);
					_partSelection.ContainerParent.SetParent(gameObject.transform, worldPositionStays: true);
					gameObject.transform.position = attachmentPosition;
					gameObject.transform.Rotate(closestAttachPoint.transform.forward, num3, Space.World);
					_partSelection.ContainerParent.SetParent(null, worldPositionStays: true);
					Object.Destroy(gameObject);
					result = true;
				}
			}
			return result;
		}

		private List<RaycastHit> GetHitResults(Ray screenRay, AttachPointScript attachPoint)
		{
			Ray ray = ((!attachPoint.AttachPoint.RayCastFromCursor || attachPoint.PartScript != _tool.SelectedPart) ? WorldPointToRay(attachPoint.transform.position) : screenRay);
			int num = 4096;
			if (!attachPoint.AttachPoint.IgnoreSurfaces)
			{
				num |= 0x2000;
			}
			RaycastHit[] array = null;
			array = ((!attachPoint.AttachPoint.AllowRotation || attachPoint.AttachPoint.IgnoreSurfaces) ? Physics.SphereCastAll(ray, 0.25f, 10000f, num) : Physics.RaycastAll(ray, 10000f, num));
			return array.OrderBy((RaycastHit x) => x.distance).ToList();
		}

		private void MatchTargetRotation(AttachPointScript selectedAttachPoint, Vector3 attachmentPosition, Vector3 closestAttachPointNormal, AttachPointScript closestAttachPoint)
		{
			Vector3 preferredUp = selectedAttachPoint.AttachPoint.UpVectorOverride ?? closestAttachPoint.transform.up;
			Vector3 forward = closestAttachPoint.transform.forward;
			GetForwardAndUpVectorsForRayHit(preferredUp, closestAttachPointNormal, forward, out var forward2, out var up);
			GameObject gameObject = new GameObject("AttachPointRotation");
			gameObject.transform.localScale = Vector3.one;
			gameObject.transform.SetPositionAndRotation(selectedAttachPoint.transform.position, selectedAttachPoint.transform.rotation);
			_partSelection.ContainerParent.SetParent(gameObject.transform, worldPositionStays: true);
			gameObject.transform.position = attachmentPosition;
			if (selectedAttachPoint.AttachPoint.AllowInvertedConnection)
			{
				if (Vector3.Dot(selectedAttachPoint.WorldNormal, forward2) < 0f)
				{
					forward2 = -forward2;
				}
			}
			else
			{
				forward2 = -forward2;
			}
			gameObject.transform.rotation = Quaternion.LookRotation(forward2, up);
			_partSelection.ContainerParent.SetParent(null, worldPositionStays: true);
			Object.Destroy(gameObject);
		}
	}
}

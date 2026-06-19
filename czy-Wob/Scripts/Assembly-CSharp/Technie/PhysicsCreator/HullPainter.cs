using System.Collections.Generic;
using UnityEngine;

namespace Technie.PhysicsCreator
{
	public class HullPainter : MonoBehaviour
	{
		public PaintingData paintingData;

		public HullData hullData;

		private List<HullMapping> hullMapping;

		private void OnDestroy()
		{
		}

		public void CreateColliderComponents()
		{
			CreateHullMapping();
			foreach (Hull hull in paintingData.hulls)
			{
				UpdateCollider(hull);
			}
		}

		public void RemoveAllColliders()
		{
			if (hullMapping == null)
			{
				return;
			}
			foreach (HullMapping item in hullMapping)
			{
				DestroyImmediateWithUndo(item.generatedCollider);
			}
			for (int num = hullMapping.Count - 1; num >= 0; num--)
			{
				if (hullMapping[num].targetChild != null)
				{
					hullMapping.RemoveAt(num);
				}
			}
		}

		public void RemoveAllGenerated()
		{
			CreateHullMapping();
			foreach (HullMapping item in hullMapping)
			{
				DestroyImmediateWithUndo(item.generatedCollider);
				if (item.targetChild != null)
				{
					DestroyImmediateWithUndo(item.targetChild.gameObject);
				}
			}
		}

		private static bool IsDeletable(GameObject obj)
		{
			Component[] components = obj.GetComponents<Component>();
			int num = 0;
			Component[] array = components;
			foreach (Component component in array)
			{
				if (component is Transform || component is Collider || component is HullPainter || component is HullPainterChild)
				{
					num++;
				}
			}
			return components.Length == num;
		}

		private static void DestroyImmediateWithUndo(Object obj)
		{
			if (!(obj == null))
			{
				Object.DestroyImmediate(obj);
			}
		}

		private void CreateHullMapping()
		{
			if (this.hullMapping == null)
			{
				this.hullMapping = new List<HullMapping>();
			}
			for (int num = this.hullMapping.Count - 1; num >= 0; num--)
			{
				HullMapping hullMapping = this.hullMapping[num];
				if (hullMapping == null || hullMapping.sourceHull == null || (hullMapping.generatedCollider == null && hullMapping.targetChild == null))
				{
					this.hullMapping.RemoveAt(num);
				}
			}
			foreach (Hull hull2 in paintingData.hulls)
			{
				if (IsMapped(hull2))
				{
					Collider collider = FindExistingCollider(this.hullMapping, hull2);
					bool num2 = hull2.type == HullType.ConvexHull && collider is MeshCollider;
					bool flag = hull2.type == HullType.Box && collider is BoxCollider;
					bool flag2 = hull2.type == HullType.Sphere && collider is SphereCollider;
					bool flag3 = hull2.type == HullType.Face && collider is MeshCollider;
					bool num3 = num2 || flag || flag2 || flag3;
					bool flag4 = collider == null || hull2.isChildCollider == (collider.transform.parent == base.transform);
					if (!(num3 && flag4))
					{
						DestroyImmediateWithUndo(collider);
						RemoveMapping(hull2);
					}
				}
			}
			List<Hull> list = new List<Hull>();
			List<Collider> list2 = new List<Collider>();
			List<HullPainterChild> list3 = new List<HullPainterChild>();
			foreach (Hull hull3 in paintingData.hulls)
			{
				if (!IsMapped(hull3))
				{
					list.Add(hull3);
				}
			}
			foreach (Collider item in FindLocal<Collider>())
			{
				if (!IsMapped(item))
				{
					list2.Add(item);
				}
			}
			foreach (HullPainterChild item2 in FindLocal<HullPainterChild>())
			{
				if (!IsMapped(item2))
				{
					list3.Add(item2);
				}
			}
			for (int num4 = list.Count - 1; num4 >= 0; num4--)
			{
				Hull hull = list[num4];
				for (int num5 = list2.Count - 1; num5 >= 0; num5--)
				{
					Collider collider2 = list2[num5];
					HullPainterChild hullPainterChild = null;
					if (collider2.transform.parent == base.transform)
					{
						hullPainterChild = collider2.gameObject.GetComponent<HullPainterChild>();
					}
					if (hull.isChildCollider && collider2.transform.parent == base.transform)
					{
						BoxCollider boxCollider = collider2 as BoxCollider;
						SphereCollider sphereCollider = collider2 as SphereCollider;
						MeshCollider meshCollider = collider2 as MeshCollider;
						bool num6 = hull.type == HullType.Box && collider2 is BoxCollider && Approximately(hull.collisionBox.center, boxCollider.center) && Approximately(hull.collisionBox.size, boxCollider.size);
						bool flag5 = hull.type == HullType.Sphere && collider2 is SphereCollider && hull.collisionSphere != null && Approximately(hull.collisionSphere.center, sphereCollider.center) && Approximately(hull.collisionSphere.radius, sphereCollider.radius);
						bool flag6 = hull.type == HullType.ConvexHull && collider2 is MeshCollider && meshCollider.sharedMesh == hull.collisionMesh;
						bool flag7 = hull.type == HullType.Face && collider2 is MeshCollider && meshCollider.sharedMesh == hull.faceCollisionMesh;
						if (num6 || flag5 || flag6 || flag7)
						{
							AddMapping(hull, collider2, hullPainterChild);
							list.RemoveAt(num4);
							list2.RemoveAt(num5);
							for (int i = 0; i < list3.Count; i++)
							{
								if (list3[i] == hullPainterChild)
								{
									list3.RemoveAt(i);
									break;
								}
							}
							break;
						}
					}
				}
			}
			for (int num7 = list.Count - 1; num7 >= 0; num7--)
			{
				if (list[num7].isChildCollider)
				{
					for (int num8 = list3.Count - 1; num8 >= 0; num8--)
					{
						HullPainterChild child = list3[num8];
						HullMapping hullMapping2 = FindMapping(child);
						if (hullMapping2 != null && hullMapping2.sourceHull != null)
						{
							if (hullMapping2.generatedCollider == null)
							{
								RecreateChildCollider(hullMapping2);
							}
							list.RemoveAt(num7);
							list3.RemoveAt(num8);
							break;
						}
					}
				}
			}
			foreach (HullMapping item3 in this.hullMapping)
			{
				if (item3.targetChild != null && item3.generatedCollider == null)
				{
					RecreateChildCollider(item3);
				}
			}
			foreach (HullMapping item4 in this.hullMapping)
			{
				if (item4.targetChild == null && item4.generatedCollider != null && item4.generatedCollider.transform.parent == base.transform)
				{
					HullPainterChild hullPainterChild2 = AddComponent<HullPainterChild>(item4.generatedCollider.gameObject);
					hullPainterChild2.parent = this;
					item4.targetChild = hullPainterChild2;
				}
			}
			foreach (Hull item5 in list)
			{
				if (item5.type == HullType.Box)
				{
					CreateCollider<BoxCollider>(item5);
				}
				else if (item5.type == HullType.Sphere)
				{
					CreateCollider<SphereCollider>(item5);
				}
				else if (item5.type == HullType.ConvexHull)
				{
					CreateCollider<MeshCollider>(item5);
				}
				else if (item5.type == HullType.Face)
				{
					CreateCollider<MeshCollider>(item5);
				}
			}
			foreach (Collider item6 in list2)
			{
				if (item6.gameObject == base.gameObject)
				{
					DestroyImmediateWithUndo(item6);
					continue;
				}
				GameObject gameObject = item6.gameObject;
				DestroyImmediateWithUndo(item6);
				DestroyImmediateWithUndo(gameObject.GetComponent<HullPainterChild>());
				if (IsDeletable(gameObject))
				{
					DestroyImmediateWithUndo(gameObject);
				}
			}
			foreach (HullPainterChild item7 in list3)
			{
				if (!(item7 == null))
				{
					GameObject gameObject2 = item7.gameObject;
					DestroyImmediateWithUndo(item7);
					DestroyImmediateWithUndo(gameObject2.GetComponent<Collider>());
					if (IsDeletable(gameObject2))
					{
						DestroyImmediateWithUndo(gameObject2);
					}
				}
			}
		}

		private static bool Approximately(Vector3 lhs, Vector3 rhs)
		{
			if (Mathf.Approximately(lhs.x, rhs.x) && Mathf.Approximately(lhs.y, rhs.y))
			{
				return Mathf.Approximately(lhs.z, rhs.z);
			}
			return false;
		}

		private static bool Approximately(float lhs, float rhs)
		{
			return Mathf.Approximately(lhs, rhs);
		}

		private void CreateCollider<T>(Hull sourceHull) where T : Collider
		{
			if (sourceHull.isChildCollider)
			{
				GameObject obj = CreateGameObject(sourceHull.name);
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				obj.transform.localScale = Vector3.one;
				HullPainterChild hullPainterChild = AddComponent<HullPainterChild>(obj);
				hullPainterChild.parent = this;
				T col = AddComponent<T>(obj);
				AddMapping(sourceHull, col, hullPainterChild);
			}
			else
			{
				T col2 = AddComponent<T>(base.gameObject);
				AddMapping(sourceHull, col2, null);
			}
		}

		private void RecreateChildCollider(HullMapping mapping)
		{
			if (mapping != null && mapping.sourceHull != null && mapping.sourceHull.isChildCollider)
			{
				if (mapping.sourceHull.type == HullType.Box)
				{
					RecreateChildCollider<BoxCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.Sphere)
				{
					RecreateChildCollider<SphereCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.ConvexHull)
				{
					RecreateChildCollider<MeshCollider>(mapping);
				}
				else if (mapping.sourceHull.type == HullType.Face)
				{
					RecreateChildCollider<MeshCollider>(mapping);
				}
			}
		}

		private void RecreateChildCollider<T>(HullMapping mapping) where T : Collider
		{
			if (mapping.sourceHull != null && mapping.sourceHull.isChildCollider)
			{
				T generatedCollider = AddComponent<T>(mapping.targetChild.gameObject);
				mapping.generatedCollider = generatedCollider;
			}
		}

		private void UpdateCollider(Hull hull)
		{
			Collider collider = null;
			if (hull.type == HullType.Box)
			{
				BoxCollider obj = FindExistingCollider(hullMapping, hull) as BoxCollider;
				obj.center = hull.collisionBox.center;
				obj.size = hull.collisionBox.size + (hull.enableInflation ? (Vector3.one * hull.inflationAmount) : Vector3.zero);
				collider = obj;
			}
			else if (hull.type == HullType.Sphere)
			{
				SphereCollider obj2 = FindExistingCollider(hullMapping, hull) as SphereCollider;
				obj2.center = hull.collisionSphere.center;
				obj2.radius = hull.collisionSphere.radius + (hull.enableInflation ? hull.inflationAmount : 0f);
				collider = obj2;
			}
			else if (hull.type == HullType.ConvexHull)
			{
				MeshCollider obj3 = FindExistingCollider(hullMapping, hull) as MeshCollider;
				obj3.sharedMesh = hull.collisionMesh;
				obj3.convex = true;
				collider = obj3;
			}
			else if (hull.type == HullType.Face)
			{
				MeshCollider obj4 = FindExistingCollider(hullMapping, hull) as MeshCollider;
				obj4.sharedMesh = hull.faceCollisionMesh;
				obj4.convex = true;
				collider = obj4;
			}
			if (collider != null)
			{
				collider.material = hull.material;
				collider.isTrigger = hull.isTrigger;
				if (hull.isChildCollider)
				{
					collider.gameObject.name = hull.name;
				}
			}
		}

		public void SetAllTypes(HullType newType)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.type = newType;
			}
		}

		public void SetAllMaterials(PhysicMaterial newMaterial)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.material = newMaterial;
			}
		}

		public void SetAllAsChild(bool isChild)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.isChildCollider = isChild;
			}
		}

		public void SetAllAsTrigger(bool isTrigger)
		{
			foreach (Hull hull in paintingData.hulls)
			{
				hull.isTrigger = isTrigger;
			}
		}

		private List<T> FindLocal<T>() where T : Component
		{
			List<T> list = new List<T>();
			list.AddRange(base.gameObject.GetComponents<T>());
			for (int i = 0; i < base.transform.childCount; i++)
			{
				list.AddRange(base.transform.GetChild(i).GetComponents<T>());
			}
			return list;
		}

		private bool IsMapped(Hull hull)
		{
			if (hullMapping == null)
			{
				return false;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.sourceHull == hull)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsMapped(Collider col)
		{
			if (hullMapping == null)
			{
				return false;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.generatedCollider == col)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsMapped(HullPainterChild child)
		{
			if (hullMapping == null)
			{
				return false;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.targetChild == child)
				{
					return true;
				}
			}
			return false;
		}

		private void AddMapping(Hull hull, Collider col, HullPainterChild painterChild)
		{
			HullMapping item = new HullMapping
			{
				sourceHull = hull,
				generatedCollider = col,
				targetChild = painterChild
			};
			hullMapping.Add(item);
		}

		private void RemoveMapping(Hull hull)
		{
			for (int i = 0; i < hullMapping.Count; i++)
			{
				if (hullMapping[i].sourceHull == hull)
				{
					hullMapping.RemoveAt(i);
					break;
				}
			}
		}

		private HullMapping FindMapping(HullPainterChild child)
		{
			if (hullMapping == null)
			{
				return null;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.targetChild == child)
				{
					return item;
				}
			}
			return null;
		}

		public Hull FindSourceHull(HullPainterChild child)
		{
			if (hullMapping == null)
			{
				return null;
			}
			foreach (HullMapping item in hullMapping)
			{
				if (item.targetChild == child)
				{
					return item.sourceHull;
				}
			}
			return null;
		}

		private static Collider FindExistingCollider(List<HullMapping> mappings, Hull hull)
		{
			foreach (HullMapping mapping in mappings)
			{
				if (mapping.sourceHull == hull)
				{
					return mapping.generatedCollider;
				}
			}
			return null;
		}

		private static GameObject CreateGameObject(string goName)
		{
			return new GameObject(goName);
		}

		private static T AddComponent<T>(GameObject targetObj) where T : Component
		{
			return targetObj.AddComponent<T>();
		}
	}
}

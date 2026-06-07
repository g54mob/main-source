using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Sirenix.Utilities;
using UnityEngine;
using Vectrosity;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.Selection
{
	public class ItemSelector : MonoBehaviour
	{
		public Color SelectionColor;

		public Color OverlappingColor;

		public Color SecondarySelectionColor;

		public Material SelectionLineMaterial;

		private static Color _selectionColor;

		private static Color _overlappingColor;

		private static Color _secondarySelectionColor;

		public static List<DronePart> SelectedItems = new List<DronePart>();

		private static NimbatusItem _copiedItem;

		private VectorLine _selectionVectorLine;

		private Vector3 _selectionStartPos;

		private List<DronePart> _previouslySelectedParts;

		private bool _hasRectangleStarted;

		public static DronePart GetOnlySelection()
		{
			if (SelectedItems.Count != 1)
			{
				return null;
			}
			return SelectedItems.First();
		}

		public void Start()
		{
			_selectionColor = SelectionColor;
			_overlappingColor = OverlappingColor;
			_secondarySelectionColor = SecondarySelectionColor;
			Vector3[] linePoints = new Vector3[5];
			_selectionVectorLine = new VectorLine("SelectionRectangle", linePoints, SelectionLineMaterial, 4f, LineType.Continuous, Joins.Fill);
			_selectionVectorLine.active = false;
		}

		public static bool IsSelected(DronePart dronePart)
		{
			return dronePart.IsSelected;
		}

		public static bool HasSelectedItems()
		{
			return SelectedItems.Count > 0;
		}

		public static void AddToSelection(DronePart item)
		{
			if (!item.IsSelected)
			{
				SelectedItems.Add(item);
				SetSelectionColorOnItemRecursive(item);
				SetColorOnItem(item, _selectionColor);
				item.IsSelected = true;
			}
		}

		public static void Select(DronePart item)
		{
			if (!(item == null))
			{
				SelectedItems.ForEach(delegate(DronePart i)
				{
					ResetColorOnItemRecursive(i);
					i.IsSelected = false;
				});
				SelectedItems.Clear();
				SelectedItems.Add(item);
				item.IsSelected = true;
				SetSelectionColorOnItemRecursive(item);
				SetColorOnItem(item, _selectionColor);
			}
		}

		public static void Deselect(DronePart item)
		{
			if (item.IsSelected)
			{
				SelectedItems.Remove(item);
				ResetColorOnItemRecursive(item);
				item.IsSelected = false;
			}
			SelectedItems.ForEach(SetSelectionColorOnItemRecursive);
		}

		public static void UpdateOverlappingColor(DronePart dronePart)
		{
			ResetColorOnItem(dronePart);
			if (dronePart.IsSelected)
			{
				SetColorOnItem(dronePart, _selectionColor);
			}
		}

		public static void SetSelectionColorOnItemRecursive(DronePart dronePart)
		{
			if (!IsSelected(dronePart) && dronePart.HasColorChanged)
			{
				return;
			}
			if (!IsSelected(dronePart))
			{
				if (dronePart.IsOverlapping)
				{
					SetColorOnItem(dronePart, _overlappingColor);
				}
				else
				{
					SetColorOnItem(dronePart, _secondarySelectionColor);
					dronePart.HasColorChanged = true;
				}
			}
			else
			{
				SetColorOnItem(dronePart, _selectionColor);
			}
			foreach (DronePart child in dronePart.Children)
			{
				SetSelectionColorOnItemRecursive(child);
			}
		}

		public static void SetColorOnItem(DronePart dronePart, Color newColor)
		{
			foreach (KeyValuePair<tk2dSprite, Color> sprite in dronePart.Sprites)
			{
				if (!(sprite.Key == null) && !sprite.Key.CompareTag("No Colorswap"))
				{
					sprite.Key.color = newColor;
				}
			}
		}

		public static void SetAlphaOnItem(DronePart selectedItem, float alpha)
		{
			foreach (KeyValuePair<tk2dSprite, Color> sprite in selectedItem.Sprites)
			{
				if (sprite.Key == null)
				{
					continue;
				}
				sprite.Key.color = new Color(sprite.Key.color.r, sprite.Key.color.g, sprite.Key.color.b, alpha);
				Renderer[] componentsInChildren = sprite.Key.gameObject.GetComponentsInChildren<Renderer>();
				foreach (Renderer renderer in componentsInChildren)
				{
					if (!renderer.CompareTag("No Colorswap") && renderer != null && renderer.material.HasProperty("_Color"))
					{
						renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);
					}
				}
			}
		}

		public static void ResetColorOnItemRecursive(DronePart selectedItem)
		{
			ResetColorOnItem(selectedItem);
			foreach (DronePart child in selectedItem.Children)
			{
				ResetColorOnItemRecursive(child);
			}
		}

		public static void ResetColorOnItem(DronePart selectedItem)
		{
			if (!selectedItem.IsOverlapping)
			{
				foreach (KeyValuePair<tk2dSprite, Color> sprite in selectedItem.Sprites)
				{
					if (!(sprite.Key == null) && !sprite.Key.CompareTag("No Colorswap"))
					{
						sprite.Key.color = new Color(sprite.Value.r, sprite.Value.g, sprite.Value.b, sprite.Key.color.a);
					}
				}
				return;
			}
			SetColorOnItem(selectedItem, _overlappingColor);
		}

		public void Update()
		{
			if (SelectedItems.Count == 1)
			{
				DronePart dronePart = SelectedItems.First();
				if (!(dronePart is RootDronePart))
				{
					if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.CopyDronePart))
					{
						_copiedItem = dronePart.Clone();
						DronePart dronePart2;
						if ((object)(dronePart2 = _copiedItem as DronePart) != null)
						{
							dronePart2.SetDrone(DronePartManager.Instance.ActiveDrone);
						}
						_copiedItem.gameObject.SetActive(false);
					}
					if (DragAndDropHelper.DraggedItem == null && BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.DuplicateDronePart))
					{
						DronePart dronePart3 = null;
						DronePart dronePart4 = dronePart;
						if (dronePart4 != null)
						{
							dronePart3 = dronePart4.ParentDronePart;
						}
						DronePart dronePart5 = dronePart.Clone() as DronePart;
						if (dronePart5 != null)
						{
							Select(dronePart5);
							dronePart5.IgnoreOffset = true;
							dronePart5.SetDrone(DronePartManager.Instance.ActiveDrone);
							dronePart5.gameObject.SetActive(true);
							DragAndDropHelper.DraggedItem = dronePart5;
							if (dronePart3 != null)
							{
								dronePart3.OnDrop(dronePart5.gameObject);
							}
						}
					}
				}
			}
			if (DragAndDropHelper.DraggedItem == null && BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.PasteDronePart) && _copiedItem != null)
			{
				DronePart dronePart6 = null;
				DronePart dronePart7 = SelectedItems.FirstOrDefault();
				if (dronePart7 != null)
				{
					dronePart6 = dronePart7.ParentDronePart;
				}
				DronePart dronePart8 = _copiedItem.Clone() as DronePart;
				if (dronePart8 != null)
				{
					Select(dronePart8);
					dronePart8.IgnoreOffset = true;
					dronePart8.SetDrone(DronePartManager.Instance.ActiveDrone);
					dronePart8.gameObject.SetActive(true);
					DragAndDropHelper.DraggedItem = dronePart8;
					if (dronePart6 != null)
					{
						dronePart6.OnDrop(dronePart8.gameObject);
					}
				}
			}
			if (!RuntimeGlobals.StopInteraction)
			{
				DoFlipping();
				if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.DeleteDronePart))
				{
					foreach (DronePart item in SelectedItems.ToList())
					{
						item.Delete();
					}
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.Delete);
				}
			}
			if (BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.MultiSelect) && Input.GetMouseButton(0))
			{
				if (Input.GetMouseButtonDown(0))
				{
					_selectionStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					_selectionStartPos.z = -50f;
					_previouslySelectedParts = new List<DronePart>();
				}
				Vector3 b = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				b.z = -50f;
				Vector3 topLeft = new Vector3(Mathf.Min(_selectionStartPos.x, b.x), Mathf.Max(_selectionStartPos.y, b.y), -50f);
				Vector3 bottomRight = new Vector3(Mathf.Max(_selectionStartPos.x, b.x), Mathf.Min(_selectionStartPos.y, b.y), -50f);
				Vector3 center = Vector3.Lerp(_selectionStartPos, b, 0.5f);
				Vector3 halfSize = new Vector3(Mathf.Abs(_selectionStartPos.x - b.x) / 2f, Mathf.Abs(_selectionStartPos.y - b.y) / 2f, 100f);
				if (_hasRectangleStarted || halfSize.x > 0.5f || halfSize.y > 0.5f)
				{
					_hasRectangleStarted = true;
					_selectionVectorLine.active = true;
					_selectionVectorLine.MakeRect(topLeft, bottomRight);
					_selectionVectorLine.Draw3D();
					List<DronePart> selectedParts = GetSelectedParts(center, halfSize);
					foreach (DronePart item2 in _previouslySelectedParts.ToList())
					{
						if (!item2.IsInRectangle)
						{
							if (IsSelected(item2))
							{
								Deselect(item2);
							}
							else
							{
								AddToSelection(item2);
							}
							item2.IsPreselected = false;
							_previouslySelectedParts.Remove(item2);
						}
					}
					foreach (DronePart item3 in selectedParts)
					{
						item3.IsInRectangle = false;
						if (!item3.IsPreselected)
						{
							item3.IsPreselected = true;
							_previouslySelectedParts.Add(item3);
							if (IsSelected(item3))
							{
								Deselect(item3);
							}
							else
							{
								AddToSelection(item3);
							}
						}
					}
				}
			}
			else
			{
				if (_previouslySelectedParts != null && _previouslySelectedParts.Count > 0)
				{
					_previouslySelectedParts.ForEach(delegate(DronePart p)
					{
						p.IsPreselected = false;
					});
					_previouslySelectedParts.Clear();
				}
				_hasRectangleStarted = false;
				_selectionVectorLine.active = false;
			}
			_selectionColor = SelectionColor;
			_overlappingColor = OverlappingColor;
			_secondarySelectionColor = SecondarySelectionColor;
		}

		private List<DronePart> GetSelectedParts(Vector3 center, Vector3 halfSize)
		{
			List<DronePart> list = new List<DronePart>();
			RaycastHit[] array = Physics.BoxCastAll(center, halfSize, Vector3.forward);
			foreach (RaycastHit raycastHit in array)
			{
				DronePart component = raycastHit.collider.gameObject.GetComponent<DronePart>();
				if (!(component == null) && !component.IsInRectangle)
				{
					component.IsInRectangle = true;
					list.Add(component);
				}
			}
			return list;
		}

		private void DoFlipping()
		{
			List<DronePart> list = new List<DronePart>();
			if (DragAndDropHelper.DraggedItem is DronePart)
			{
				list.Add(DragAndDropHelper.DraggedItem as DronePart);
			}
			else
			{
				list.AddRange(SelectedItems);
			}
			if (list.Count > 0)
			{
				if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.FlipDronePartVertical))
				{
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.FlipVertical);
					list.ForEach(FlipVertically);
				}
				if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.FlipDronePartHorizontal))
				{
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.FlipHorizontal);
					list.ForEach(FlipHorizontally);
				}
			}
		}

		private void FlipVertically(DronePart itemToFlip)
		{
			itemToFlip.Unparent();
			itemToFlip.FlipVertically(itemToFlip.transform.position);
			itemToFlip.Reparent();
		}

		private void FlipHorizontally(DronePart itemToFlip)
		{
			itemToFlip.Unparent();
			itemToFlip.FlipHorizontally(itemToFlip.transform.position);
			itemToFlip.Reparent();
		}

		public void OnDisable()
		{
			SelectedItems.Clear();
			_copiedItem = null;
		}

		public static void Reset()
		{
			SelectedItems.ForEach(delegate(DronePart i)
			{
				ResetColorOnItemRecursive(i);
				i.IsSelected = false;
			});
			SelectedItems.Clear();
		}

		public static bool CanBeEdited<T>(bool checkAttribute)
		{
			if (SelectedItems.All((DronePart i) => i is T))
			{
				DronePart dronePart = SelectedItems.FirstOrDefault();
				if (dronePart != null && (!checkAttribute || dronePart.GetType().GetCustomAttribute<CustomDronePartEditor>() == null))
				{
					Type type = dronePart.GetType();
					if (SelectedItems.All((DronePart i) => i.GetType() == type))
					{
						return DragAndDropHelper.DraggedItem == null;
					}
					return false;
				}
			}
			return false;
		}
	}
}

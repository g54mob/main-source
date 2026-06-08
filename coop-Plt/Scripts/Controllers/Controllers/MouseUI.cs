using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
	public class MouseUI : MonoBehaviour
	{
		public static MouseUI Main;

		public Camera UICamera;

		public float DistanceToUI = 10f;

		private InputActionMap MouseMap;

		private InputAction UIMousePosition;

		private InputAction UIMouseClick;

		private List<IMouseUIElement> Elements = new List<IMouseUIElement>();

		private List<IMouseUIElement> CollisionElements = new List<IMouseUIElement>();

		private Vector3 WorldMousePos;

		private Vector2 LastMousePos;

		private float LastMoveTime;

		private List<IMouseUIElement> TempList = new List<IMouseUIElement>();

		private void Start()
		{
			Main = this;
			MouseMap = new InputActionMap();
			UIMousePosition = MouseMap.AddAction("UIMouse");
			UIMousePosition.AddBinding("<Mouse>/position");
			UIMouseClick = MouseMap.AddAction("MouseClick");
			UIMouseClick.AddBinding("<Mouse>/leftButton");
			UIMouseClick.performed += OnClick;
			UIMouseClick.canceled += OnRelease;
			MouseMap.Enable();
		}

		public void Update()
		{
			bool num = UpdateMousePosition();
			UpdateMouseVisibility();
			if (num)
			{
				UpdateCollisions();
			}
		}

		public void Register(IMouseUIElement element)
		{
			Elements.Add(element);
		}

		public void Deregister(IMouseUIElement element)
		{
			Elements.Remove(element);
			CollisionElements.Remove(element);
		}

		private void OnClick(InputAction.CallbackContext obj)
		{
			UpdateCollisions();
			TempList.Clear();
			CollisionElements.ForEach(delegate(IMouseUIElement e)
			{
				TempList.Add(e);
			});
			foreach (IMouseUIElement temp in TempList)
			{
				temp?.OnMouseUIDown();
			}
		}

		private void OnRelease(InputAction.CallbackContext obj)
		{
			UpdateCollisions();
			TempList.Clear();
			CollisionElements.ForEach(delegate(IMouseUIElement e)
			{
				TempList.Add(e);
			});
			foreach (IMouseUIElement temp in TempList)
			{
				temp?.OnMouseUIUp(WorldMousePos);
			}
		}

		private void UpdateMouseVisibility()
		{
			Cursor.visible = Time.realtimeSinceStartup - LastMoveTime < 10f;
		}

		private bool UpdateMousePosition()
		{
			Vector2 vector = UIMousePosition.ReadValue<Vector2>();
			WorldMousePos = UICamera.ScreenToWorldPoint(new Vector3(vector.x, vector.y, DistanceToUI));
			bool num = (LastMousePos - vector).SqrMagnitude() > 0.001f;
			if (num)
			{
				LastMoveTime = Time.realtimeSinceStartup;
			}
			LastMousePos = vector;
			return num;
		}

		private void UpdateCollisions()
		{
			PurgeElementList();
			foreach (IMouseUIElement element in Elements)
			{
				bool flag = CollisionElements.Contains(element);
				bool num = element.IntersectsPoint(WorldMousePos);
				if (num && !flag)
				{
					RollOver(element);
				}
				if (!num && flag)
				{
					RollOut(element);
				}
			}
		}

		private void PurgeElementList()
		{
			for (int num = Elements.Count - 1; num >= 0; num--)
			{
				IMouseUIElement mouseUIElement = Elements[num];
				if ((MonoBehaviour)mouseUIElement == null)
				{
					CollisionElements.Remove(mouseUIElement);
					Elements.RemoveAt(num);
				}
			}
		}

		private void RollOver(IMouseUIElement element)
		{
			CollisionElements.Add(element);
			element.OnMouseUIRollOver();
		}

		private void RollOut(IMouseUIElement element)
		{
			CollisionElements.Remove(element);
			element.OnMouseUIRollOut();
		}
	}
}

using System;
using Data.Shapes;
using Presentation.Shapes;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickableShape : MonoBehaviour
{
	private ShapeLoader _shapeLoader;

	private int _stackIndex;

	private Camera _camera;

	private bool _isPressed;

	public Action<ClickableShape, Vector3> OnShapePressed = delegate
	{
	};

	public Action<ClickableShape> OnShapeReleased = delegate
	{
	};

	public ShapeLoader ShapeLoader => _shapeLoader;

	public int StackIndex => _stackIndex;

	public static ClickableShape CreateClickableShape(ShapeData shapeData, ShapeMeshLibrary shapeMeshLibrary, Material material, Camera camera, int stackIndex, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
	{
		ShapeLoader shapeLoader = ShapeLoader.CreateFromShapeData(shapeData, shapeMeshLibrary, material, position, rotation, createCollider: true);
		ClickableShape clickableShape = shapeLoader.gameObject.AddComponent<ClickableShape>();
		clickableShape._shapeLoader = shapeLoader;
		clickableShape._camera = camera;
		clickableShape._stackIndex = stackIndex;
		return clickableShape;
	}

	private void Update()
	{
		if (!_isPressed && Mouse.current.leftButton.wasPressedThisFrame)
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			if (Physics.Raycast(_camera.ScreenPointToRay(vector), out var hitInfo) && hitInfo.collider == _shapeLoader.MeshCollider)
			{
				_isPressed = true;
				OnShapePressed(this, hitInfo.point);
			}
		}
		if (_isPressed && Mouse.current.leftButton.wasReleasedThisFrame)
		{
			_isPressed = false;
			OnShapeReleased(this);
		}
	}

	public void SetIsPressed(bool isPressed)
	{
		_isPressed = isPressed;
	}
}

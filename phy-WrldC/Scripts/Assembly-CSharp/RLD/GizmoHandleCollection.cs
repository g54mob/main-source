using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GizmoHandleCollection
	{
		private Gizmo _gizmo;

		private List<IGizmoHandle> _handles = new List<IGizmoHandle>();

		private Dictionary<int, IGizmoHandle> _idToHandle = new Dictionary<int, IGizmoHandle>();

		public Gizmo Gizmo => _gizmo;

		public int Count => _handles.Count;

		public IGizmoHandle this[int index] => _handles[index];

		public GizmoHandleCollection(Gizmo gizmo)
		{
			_gizmo = gizmo;
		}

		public void Clear()
		{
			_handles.Clear();
			_idToHandle.Clear();
		}

		public IGizmoHandle GetHandleById(int handleId)
		{
			return _idToHandle[handleId];
		}

		public bool Contains(IGizmoHandle handle)
		{
			return _idToHandle.ContainsKey(handle.Id);
		}

		public bool Contains(int handleId)
		{
			return _idToHandle.ContainsKey(handleId);
		}

		public void Add(IGizmoHandle handle)
		{
			if (!Contains(handle) && handle.Gizmo == Gizmo)
			{
				_handles.Add(handle);
				_idToHandle.Add(handle.Id, handle);
			}
		}

		public void Remove(IGizmoHandle handle)
		{
			_handles.Remove(handle);
			_idToHandle.Remove(handle.Id);
		}

		public List<IGizmoHandle> GetAll()
		{
			return new List<IGizmoHandle>(_handles);
		}

		public List<GizmoHandleHoverData> GetAllHandlesHoverData(Ray hoverRay)
		{
			List<GizmoHandleHoverData> list = new List<GizmoHandleHoverData>(10);
			foreach (IGizmoHandle handle in _handles)
			{
				GizmoHandleHoverData hoverData = handle.GetHoverData(hoverRay);
				if (hoverData != null)
				{
					list.Add(hoverData);
				}
			}
			return list;
		}
	}
}

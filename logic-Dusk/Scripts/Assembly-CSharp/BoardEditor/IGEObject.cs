using System.Collections.Generic;
using UnityEngine;

namespace BoardEditor
{
	public interface IGEObject
	{
		string ID { get; set; }

		bool isInEditMode { get; }

		bool isActive { get; }

		bool isMouseOver { get; }

		bool canRotate { get; }

		GEObjectTypeEnum objectType { get; }

		Vector2 currentLLCorner { get; }

		List<IGEObject> linkedObjects { get; }

		Color baseLightColor { get; }

		Color baseDarkColor { get; }

		List<DesignedDungeonManager.MetaData> metaDataList { get; }

		event CommonEvents.MDownOnObjectEventHandler MouseDownOnObjectEvent;

		event CommonEvents.MUpOnObjectEventHandler MouseUpOnObjectEvent;

		event CommonEvents.ObjectMEnterEventHandler MouseEnterRoomEvent;

		event CommonEvents.ObjectActivateChangedEventHandler ObjectActivateChangedEvent;

		void AttachEditor(GameEditorScript ge);

		void DetachEditor();

		void DeActivate();

		void Activate();

		void Destroy();

		List<TileData> GetEdgeTiles();

		List<TileData> GetHorizEdgeTiles(int side);

		List<TileData> GetVertEdgeTiles(int side);

		void HighlightEdge(HighlightTypeEnum highlightType);

		void MouseNoLongerOver();

		void ResetEdge();

		void SetLLCorner(int c, int r);

		void SetLLCorner(Vector2 corner);

		void RefreshTileProperties();

		void Move(int cDelta, int rDelta);

		void Rotate();

		Rect GetRect();

		Rect GetBoundsAsRect();

		void GetBoundsAsRect(out Rect rect);

		void BreakLinkToObject(IGEObject obj);

		void LinkToObject(IGEObject obj);

		void ExternalMouseUp(TileData tile);

		void ExternalMouseDown(TileData tile);

		void SetMetaData(string name, string value);

		string GetMetaDataValue(string name);
	}
}

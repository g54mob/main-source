using System.Collections.Generic;
using UnityEngine;

public class UndoManager
{
	public enum UndoType
	{
		TERRAIN = 0,
		SCAPE = 1
	}

	private class UndoData
	{
		public UndoType undoType;

		public byte[] terrain;

		public short[] terrainTexture;

		public byte[] terrainTextureBrightness;

		public short[] cliffTexture;

		public byte[] terrainTextureScale;

		public byte[] cliffTextureScale;

		public Color32[] detailPixels;

		public byte[] terrainDecayLevels;

		public int[] terrainDecay;

		public byte[] terrainDecayMinHeights;

		public byte[] terrainBreederLevels;

		public int[] digitalisData;

		public bool[] digitalisGrowthData;

		public List<ScapePanel.ScapeItem> scapeItems;

		public UndoData(UndoType undoType)
		{
		}
	}

	private Stack<UndoData> undoStack;

	private Stack<UndoData> redoStack;

	public void AddUndo(UndoType undoType)
	{
	}

	public void RestoreUndo()
	{
	}

	public void Redo()
	{
	}

	private void HandleUndoData(UndoData ud, bool redo)
	{
	}

	private UndoData CreateUndoTerrain()
	{
		return null;
	}

	private void RestoreUndoTerrain(UndoData ud)
	{
	}
}

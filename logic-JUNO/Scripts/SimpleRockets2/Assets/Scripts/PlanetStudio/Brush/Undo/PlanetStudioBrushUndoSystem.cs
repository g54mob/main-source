using System;
using System.Collections.Generic;
using ModApi.CelestialData;
using ModApi.Common.SimpleTypes;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Brush.Undo
{
	public class PlanetStudioBrushUndoSystem
	{
		private class UndoStep
		{
			public Guid? LoadedFromFileId { get; }

			public IReadOnlyList<UndoStepTexture> Textures { get; }

			public UndoStep(Guid? loadedFromFileId, IEnumerable<UndoStepTexture> textures)
			{
				LoadedFromFileId = loadedFromFileId;
				Textures = new List<UndoStepTexture>(textures);
			}
		}

		private class UndoStepTexture
		{
			public int FaceIndex { get; }

			public ColorRGB24[] TextureData { get; }

			public UndoStepTexture(int faceIndex, ColorRGB24[] textureData)
			{
				FaceIndex = faceIndex;
				TextureData = textureData;
			}
		}

		private static readonly IReadOnlyList<int> _allTextureFaceIndices = new List<int> { 0, 1, 2, 3, 4, 5 };

		private BrushSphereScript _brushSphereScript;

		private List<UndoStep> _steps;

		public bool CanRedo => CurrentStepIndex < _steps.Count;

		public bool CanUndo => CurrentStepIndex > 1;

		public int CurrentStepIndex { get; private set; }

		public int MaxUndoSteps { get; set; }

		public int TotalSteps => _steps.Count;

		public PlanetStudioBrushUndoSystem(BrushSphereScript brushSphereScript, int maxUndoSteps)
		{
			_brushSphereScript = brushSphereScript;
			MaxUndoSteps = maxUndoSteps;
			_steps = new List<UndoStep>();
			CurrentStepIndex = 0;
		}

		public void ClearRedoSteps()
		{
			int num = _steps.Count - CurrentStepIndex;
			if (num > 0)
			{
				_steps.RemoveRange(CurrentStepIndex, num);
			}
		}

		public void CreateUndoStep(IEnumerable<int> textureFaceIndices = null)
		{
			List<UndoStepTexture> list = new List<UndoStepTexture>();
			foreach (int item in textureFaceIndices ?? _allTextureFaceIndices)
			{
				ColorRGB24[] textureData = _brushSphereScript.GetTextureData(item);
				list.Add(new UndoStepTexture(item, textureData));
			}
			CreateUndoStep(new UndoStep(null, list));
		}

		public void CreateUndoStep(CelestialFile file)
		{
			if (CurrentStepIndex > 0 && _steps[CurrentStepIndex - 1].LoadedFromFileId == file.Id)
			{
				return;
			}
			List<UndoStepTexture> list = new List<UndoStepTexture>();
			foreach (int allTextureFaceIndex in _allTextureFaceIndices)
			{
				ColorRGB24[] textureData = _brushSphereScript.GetTextureData(allTextureFaceIndex);
				list.Add(new UndoStepTexture(allTextureFaceIndex, textureData));
			}
			CreateUndoStep(new UndoStep(file.Id, list));
		}

		public void Redo()
		{
			if (!CanRedo)
			{
				Debug.LogError("Unable to redo");
				return;
			}
			foreach (UndoStepTexture texture in _steps[CurrentStepIndex++].Textures)
			{
				_brushSphereScript.SetTextureData(texture.FaceIndex, texture.TextureData);
			}
		}

		public void Undo()
		{
			if (!CanUndo)
			{
				Debug.LogError("Unable to undo");
				return;
			}
			foreach (UndoStepTexture texture in _steps[--CurrentStepIndex - 1].Textures)
			{
				_brushSphereScript.SetTextureData(texture.FaceIndex, texture.TextureData);
			}
		}

		private void CreateUndoStep(UndoStep step)
		{
			ClearRedoSteps();
			int num = _steps.Count - MaxUndoSteps;
			if (num > 0)
			{
				_steps.RemoveRange(0, num);
			}
			_steps.Add(step);
			CurrentStepIndex = _steps.Count;
		}
	}
}

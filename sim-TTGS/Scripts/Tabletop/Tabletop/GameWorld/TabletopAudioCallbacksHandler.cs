using System;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopAudioCallbacksHandler : MonoBehaviour
	{
		private void OnEnable()
		{
			MiniatureBoxProduct.StartOpenBox += OnBoxStartOpen;
			MiniatureBoxProduct.BoxShake += OnBoxShake;
			Collection.CollectedNewPieces += OnBoxOpened;
			MiniatureOpening_HUDPopupModule.OnNewPiece += OnPiece;
			MiniatureAssembly.PieceAdded += OnAssemble;
			MiniatureAssembly.AssemblyCompleted += OnAssembleCompleted;
			UI_BasePaintMiniGame.OnTry = (Action<bool, int>)Delegate.Combine(UI_BasePaintMiniGame.OnTry, new Action<bool, int>(OnPaint));
		}

		private void OnDisable()
		{
			MiniatureBoxProduct.StartOpenBox -= OnBoxStartOpen;
			MiniatureBoxProduct.BoxShake -= OnBoxShake;
			Collection.CollectedNewPieces -= OnBoxOpened;
			MiniatureOpening_HUDPopupModule.OnNewPiece -= OnPiece;
			MiniatureAssembly.PieceAdded -= OnAssemble;
			MiniatureAssembly.AssemblyCompleted -= OnAssembleCompleted;
			UI_BasePaintMiniGame.OnTry = (Action<bool, int>)Delegate.Remove(UI_BasePaintMiniGame.OnTry, new Action<bool, int>(OnPaint));
		}

		private void OnBoxStartOpen(int _)
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.FigurineBoxStartOpen);
		}

		private void OnBoxShake()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.FigurineBoxShake);
		}

		private void OnBoxOpened()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.FigurineBoxOpened);
		}

		private void OnPiece(int rarity)
		{
			switch (rarity)
			{
			case 1:
				AudioManager.PlaySingleEvent(WorldAudioSettings.FigurinePieceBasic);
				break;
			case 2:
			case 3:
			case 4:
				AudioManager.PlaySingleEvent(WorldAudioSettings.FigurinePieceLarge);
				break;
			case 5:
				AudioManager.PlaySingleEvent(WorldAudioSettings.FigurinePieceHero);
				break;
			}
		}

		private void OnAssemble()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.FigurineAssemble);
		}

		private void OnAssembleCompleted()
		{
			AudioManager.PlaySingleEvent(WorldAudioSettings.FigurineAssembleCompleted);
		}

		private void OnPaint(bool success, int score)
		{
			if (!success)
			{
				AudioManager.PlaySingleEvent(WorldAudioSettings.FigurinePaintFail);
			}
			else if (score >= 350)
			{
				if (score < 430)
				{
					AudioManager.PlaySingleEvent(WorldAudioSettings.FigurinePaintGreat);
				}
				else
				{
					AudioManager.PlaySingleEvent(WorldAudioSettings.FigurinePaintPrefect);
				}
			}
			else
			{
				AudioManager.PlaySingleEvent(WorldAudioSettings.FigurinePaintOk);
			}
		}
	}
}

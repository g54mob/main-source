using System;
using UnityEngine;

public class SeasonalMultilayerSprite : MultilayerSprite
{
	[Serializable]
	public class Replacement
	{
		public AsciiSprite sprite;

		public int extraOffsetX;

		public int extraOffsetY;

		public bool syncFrames;

		public string eventId;
	}

	public Replacement[] replacements;

	private Replacement selectedReplacement;

	private int lastDay = -1;

	private int lastMonth = -1;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (HasReplacement())
		{
			if (GetReplacement().syncFrames)
			{
				GetReplacement().sprite.SetFrameIndex(GetFrameIndex());
			}
			offsetX += GetReplacement().extraOffsetX;
			offsetY += GetReplacement().extraOffsetY;
			GetReplacement().sprite.Draw(r, offsetX, offsetY);
		}
		else
		{
			base.Draw(r, offsetX, offsetY);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
	{
		if (HasReplacement())
		{
			if (GetReplacement().syncFrames)
			{
				GetReplacement().sprite.SetFrameIndex(GetFrameIndex());
			}
			offsetX += GetReplacement().extraOffsetX;
			offsetY += GetReplacement().extraOffsetY;
			GetReplacement().sprite.Draw(r, offsetX, offsetY, overrideForeground, overrideBackground);
		}
		else
		{
			base.Draw(r, offsetX, offsetY, overrideForeground, overrideBackground);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
	{
		if (HasReplacement())
		{
			if (GetReplacement().syncFrames)
			{
				GetReplacement().sprite.SetFrameIndex(GetFrameIndex());
			}
			offsetX += GetReplacement().extraOffsetX;
			offsetY += GetReplacement().extraOffsetY;
			GetReplacement().sprite.Draw(r, offsetX, offsetY, overrideForeground);
		}
		else
		{
			base.Draw(r, offsetX, offsetY, overrideForeground);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply)
	{
		if (HasReplacement())
		{
			if (GetReplacement().syncFrames)
			{
				GetReplacement().sprite.SetFrameIndex(GetFrameIndex());
			}
			offsetX += GetReplacement().extraOffsetX;
			offsetY += GetReplacement().extraOffsetY;
			GetReplacement().sprite.Draw(r, offsetX, offsetY, colorMultiply);
		}
		else
		{
			base.Draw(r, offsetX, offsetY, colorMultiply);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		if (HasReplacement())
		{
			if (GetReplacement().syncFrames)
			{
				GetReplacement().sprite.SetFrameIndex(GetFrameIndex());
			}
			offsetX += GetReplacement().extraOffsetX;
			offsetY += GetReplacement().extraOffsetY;
			GetReplacement().sprite.Draw(r, offsetX, offsetY, colorMultiply, tint);
		}
		else
		{
			base.Draw(r, offsetX, offsetY, colorMultiply, tint);
		}
	}

	private bool HasReplacement()
	{
		UpdateReplacement();
		return selectedReplacement != null;
	}

	private Replacement GetReplacement()
	{
		return selectedReplacement;
	}

	private void UpdateReplacement()
	{
		DateTime now = DateTime.Now;
		int day = now.Day;
		int month = now.Month;
		if (lastDay == day && lastMonth == month)
		{
			return;
		}
		lastDay = day;
		lastMonth = month;
		bool flag = EventController.singleton.CanPlayerSeeEvents();
		selectedReplacement = null;
		for (int i = 0; i < replacements.Length; i++)
		{
			Replacement replacement = replacements[i];
			if (string.IsNullOrEmpty(replacement.eventId))
			{
				selectedReplacement = replacement;
			}
			else if (flag && EventController.singleton.IsEventActiveAndStarted(replacement.eventId))
			{
				selectedReplacement = replacement;
				break;
			}
		}
		if (selectedReplacement != null && selectedReplacement.sprite != null)
		{
			selectedReplacement.sprite.Load();
		}
	}
}

using System;
using System.Collections.Generic;
using Assets.Scripts.Ui.Sharing.Upload;
using ModApi.Common.Extensions;
using ModApi.Mods;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers
{
	public abstract class UploadContentFormData
	{
		public enum PictureFormatType
		{
			PNG = 0,
			JPG = 1
		}

		public static string PictureExtension => PictureFormat switch
		{
			PictureFormatType.JPG => "jpg", 
			PictureFormatType.PNG => "png", 
			_ => throw new InvalidOperationException(string.Format("Unsupported picture format:", PictureFormat)), 
		};

		public static string PictureExtensionMimeType => PictureFormat switch
		{
			PictureFormatType.JPG => "image/jpeg", 
			PictureFormatType.PNG => "image/png", 
			_ => throw new InvalidOperationException(string.Format("Unsupported picture format:", PictureFormat)), 
		};

		public static PictureFormatType PictureFormat { get; } = PictureFormatType.JPG;

		public string AncestryId { get; private set; }

		public string Description { get; private set; }

		public bool IsPublic { get; private set; }

		public string Name { get; private set; }

		public string ParentAncestryId { get; private set; }

		public string RequiredMods { get; private set; }

		public List<byte[]> Screenshots { get; private set; }

		public bool ValidPhotoChecksums { get; private set; }

		public UploadContentFormData(UploadContentModel model, string ancestryId, string parentAncestryId, RequiredModsData requiredMods)
		{
			Name = model.Name;
			Description = model.Description;
			IsPublic = model.IsPublic;
			ValidPhotoChecksums = model.ValidPhotoChecksums;
			AncestryId = ancestryId;
			ParentAncestryId = parentAncestryId;
			RequiredMods = ((requiredMods == null || requiredMods.Mods.Count == 0) ? null : requiredMods.GenerateXml().ToString());
			Screenshots = new List<byte[]>();
			foreach (Texture2D screenshot in model.Screenshots)
			{
				byte[] item = EncodeScreenshot(screenshot);
				Screenshots.Add(item);
			}
		}

		public virtual void UpdateFormData(WWWForm form)
		{
			form.AddField("Name", Name);
			form.AddField("Description", Description);
			form.AddField("Public", IsPublic);
			form.AddField("ValidPhotoChecksums", ValidPhotoChecksums);
			form.AddField("AncestryId", AncestryId);
			form.AddOptionalField("ParentAncestryId", ParentAncestryId);
			form.AddOptionalField("RequiredMods", RequiredMods);
			for (int i = 0; i < Screenshots.Count; i++)
			{
				form.AddBinaryData("UserView", Screenshots[i], $"UserView_{i}.{PictureExtension}", PictureExtensionMimeType);
			}
		}

		private static byte[] EncodeScreenshot(Texture2D texture)
		{
			return PictureFormat switch
			{
				PictureFormatType.JPG => texture.EncodeToJPG(), 
				PictureFormatType.PNG => texture.EncodeToPNG(), 
				_ => throw new InvalidOperationException(string.Format("Unsupported picture format:", PictureFormat)), 
			};
		}
	}
}

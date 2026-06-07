using System.Collections.Generic;
using NBT.Tags;
using UnityEngine;

public class ADAMessage
{
	public class ADABlock
	{
		public enum ADABLOCK_TYPE
		{
			TEXT = 0,
			IMAGE = 1
		}

		public ADABLOCK_TYPE blockType;

		public ADAMessage message;

		public int background;

		public void RemoveBlock()
		{
		}

		public void MoveBlockUp()
		{
		}

		public void MoveBlockDown()
		{
		}

		public virtual void ReadData(Tag data)
		{
		}

		public virtual TagCompound WriteData()
		{
			return null;
		}
	}

	public class ADATextBlock : ADABlock
	{
		public string text;

		public override void ReadData(Tag data)
		{
		}

		public override TagCompound WriteData()
		{
			return null;
		}
	}

	public class ADAImageBlock : ADABlock
	{
		private string builtInTextureName;

		private Texture2D texture;

		public int maxHeight;

		private void CleanUpTexture()
		{
		}

		public void AssignBuiltInTexture(string builtInName)
		{
		}

		public void AssignTexture(Texture2D tex)
		{
		}

		public bool IsBuiltIn()
		{
			return false;
		}

		public string GetBuiltInName()
		{
			return null;
		}

		public Texture2D GetTexture()
		{
			return null;
		}

		public override void ReadData(Tag data)
		{
		}

		public override TagCompound WriteData()
		{
			return null;
		}
	}

	private List<ADABlock> blocks;

	public ADATextBlock AddTextBlock()
	{
		return null;
	}

	public ADAImageBlock AddImageBlock()
	{
		return null;
	}

	public List<ADABlock> GetBlocks()
	{
		return null;
	}

	public int RemoveBlock(ADABlock block)
	{
		return 0;
	}

	public int GetBlockIndex(ADABlock block)
	{
		return 0;
	}

	public void MoveBlockUp(ADABlock block)
	{
	}

	public void MoveBlockDown(ADABlock block)
	{
	}

	public void ReadData(Tag data)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}
}

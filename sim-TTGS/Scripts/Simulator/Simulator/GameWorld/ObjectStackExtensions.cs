using System.Collections.Generic;

namespace Simulator.GameWorld
{
	public static class ObjectStackExtensions
	{
		public static void Fill(this ObjectStack stack, ProductData productData)
		{
			if (stack != null && productData != null && stack.CanWelcome(productData))
			{
				int num = 0;
				while (stack.HasSpaceLeft() && num < 100)
				{
					Product stackable = Product.Create(productData);
					stack.Stack(stackable);
					num++;
				}
			}
		}

		public static void Fill(this ObjectStack stack, ProductData productData, int amount)
		{
			int num = 0;
			if (stack != null && productData != null && stack.CanWelcome(productData))
			{
				while (stack.HasSpaceLeft() && num < amount)
				{
					Product stackable = Product.Create(productData);
					stack.Stack(stackable);
					num++;
				}
			}
		}

		public static void Fill(this ObjectStack stack, TrashData trashData, int amount)
		{
			int num = 0;
			if (stack != null && trashData != null && stack.CanWelcome(trashData))
			{
				while (stack.HasSpaceLeft() && num < amount)
				{
					Dirt dirt = Dirt.Create(trashData);
					stack.Stack(dirt as Trash);
					num++;
				}
			}
		}

		public static void PreciseFill(this ObjectStack stack, IEnumerable<ProductData> productDatas)
		{
			if (!(stack != null))
			{
				return;
			}
			foreach (ProductData productData in productDatas)
			{
				if (productData != null && stack.HasSpaceLeft())
				{
					Product stackable = Product.Create(productData);
					stack.Stack(stackable);
				}
			}
		}

		public static void PreciseFill(this ObjectStack stack, IEnumerable<TrashData> trashDatas)
		{
			if (!(stack != null))
			{
				return;
			}
			foreach (TrashData trashData in trashDatas)
			{
				if (trashData != null && stack.HasSpaceLeft())
				{
					Dirt dirt = Dirt.Create(trashData);
					stack.Stack(dirt as Trash);
				}
			}
		}
	}
}

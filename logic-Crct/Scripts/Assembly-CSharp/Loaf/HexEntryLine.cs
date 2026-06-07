using Noesis;

namespace Loaf
{
	public class HexEntryLine : UserControl
	{
		private byte[] _data;

		private int _adrStart;

		private TextBox[] entryField;

		private int[] addresses;

		private bool lockUpdate;

		public Noesis.Label AddressLabel;

		public TextBox Address0;

		public TextBox Address1;

		public TextBox Address2;

		public TextBox Address3;

		public TextBox Address4;

		public TextBox Address5;

		public TextBox Address6;

		public TextBox Address7;

		public TextBox Address8;

		public TextBox Address9;

		public TextBox Address10;

		public TextBox Address11;

		public TextBox Address12;

		public TextBox Address13;

		public TextBox Address14;

		public TextBox Address15;

		public HexEntryLine()
		{
		}

		public HexEntryLine(int adrStart, byte[] data)
		{
		}

		public void SetRow(int adrStart, byte[] data)
		{
		}

		private void CreateAddressEntryFields()
		{
		}

		private void HexEntryLine_TextChanged(object sender, RoutedEventArgs e)
		{
		}

		private void HexInput(object sender, TextCompositionEventArgs e)
		{
		}

		private void InitializeComponent()
		{
		}
	}
}

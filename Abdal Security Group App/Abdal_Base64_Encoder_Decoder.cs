using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abdal_Security_Group_App
{
    public partial class Abdal_Base64_Encoder_Decoder : Telerik.WinControls.UI.RadForm
    {
        public Abdal_Base64_Encoder_Decoder()
        {
            InitializeComponent();
        }

        private void EncryptToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (EncryptToggleSwitch.Value == true)
            {
                DecryptToggleSwitch.Value = false;
            }
            else
            {
                DecryptToggleSwitch.Value = true;
            }
        }

        private void DecryptToggleSwitch_ValueChanged(object sender, EventArgs e)
        {
            if (DecryptToggleSwitch.Value == true)
            {
                EncryptToggleSwitch.Value = false;
            }
            else
            {
                EncryptToggleSwitch.Value = true;
            }
        }

        private void EncDecButton_Click(object sender, EventArgs e)
        {


            try{

                if (StringTextEditor.Text != "")
                {

                    

                    if (EncryptToggleSwitch.Value == true)
                    {
                        // Encode
                        Chilkat.BinData bd = new Chilkat.BinData();
                        bool success = bd.AppendString(StringTextEditor.Text, "utf-8");
                        string strBase64 = bd.GetEncoded("base64");
                        ResultTextEditor.Text = strBase64;
                    }
                    else
                    {
                        // Decode 
                        Chilkat.BinData bd2 = new Chilkat.BinData();
                        bd2.AppendEncoded(StringTextEditor.Text, "base64");
                        string decoded = bd2.GetString("utf-8");
                        ResultTextEditor.Text = decoded;

                    }

                }
                else
                {
                    MessageBox.Show("The String  field must be filled");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            
           

            


        }

        private void Abdal_2Key_Triple_DES_Builder_Load(object sender, EventArgs e)
        {
            // Call Global Chilkat Unlock
            Abdal_Security_Group_App.GlobalUnlockChilkat GlobalUnlock = new Abdal_Security_Group_App.GlobalUnlockChilkat();
            GlobalUnlock.unlock();
        }
    }
}

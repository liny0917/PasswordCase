using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PasswordCase.Module;

namespace PasswordCase
{
    public partial class GenerateAutoPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * 密碼必須至少包含大小寫、數字、特殊符號各1
             * Range範圍必須介在7-15之間
             */
        }

        protected void BtnGenerate_Click(object sender, EventArgs e)
        {
            var generator = new PasswordGenerator();
            var result = generator.Generate();
            LblPw.Text = result;
        }
    }
}
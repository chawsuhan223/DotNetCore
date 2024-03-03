using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Multi modify & select Ctrl + d
namespace DotNetCore.Models
{
    [Table("Tbl_Blog")]//equal Tbl_Blog
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }

        public string BlogAuthor { get; set; }

        public string BlogContent { get; set; }

    }
public class jSonPlaceholder
{
    public int blogId { get; set; }
    public string blogTitle { get; set; }
    public string blogAuthor { get; set; }
    public string blogContent { get; set; }
}


}

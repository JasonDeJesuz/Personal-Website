using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Website_ASPNET.ViewModels
{
    public class GithubViewModel
    {
        [Display(Name = "Project Name")]
        public string name {get; set;}
        [Display(Name="Description")]
        public string description { get; set;}
        [Display(Name="Size")]
        public string size { get; set;}
        [Display(Name="Stars")]
        public string stargazers_count { get; set;}
        [Display(Name="Language")]
        public string language { get; set;}
        public string html_url { get; set;}
    }
}
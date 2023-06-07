using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Shared.Models;
public class CheckoutForm
{
    [Required(ErrorMessage = "Introduce tu nombre")]
    public string Name { get; set; } = "";
    [Required(ErrorMessage = "Introduce tu dirección")]
    public string Address { get; set; } = "";
}
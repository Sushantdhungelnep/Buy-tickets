using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuyTickets.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }

        //relationship
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}

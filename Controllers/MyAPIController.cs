using AutoMapper;
using FirstCore.Data.Models;
using FirstCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAPIController : ControllerBase
    {
        private readonly TestAvinashContext _dbcontext;
        private readonly IMapper _mapper;

        public MyAPIController(TestAvinashContext testAvinashContext, IMapper mapper)
        {

            _dbcontext = testAvinashContext;
            _mapper = mapper;
        }

        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            List<UserAddress> Originallist = _dbcontext.UserAddresses.Include(x => x.Address).ToList();

            List<UserAddressDTO> userAddressDTO = _mapper.Map<List<UserAddressDTO>>(Originallist);

            return Ok(userAddressDTO);


            //        [
            //{
            //                "userAddressId": 1,
            //        "userId": 1,
            //        "addressId": 2,
            //        "address": null,
            //        "user": null
            //    }
            //]
        }
    }
}

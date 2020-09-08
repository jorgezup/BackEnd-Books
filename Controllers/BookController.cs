using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BooksApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        Book _oBook = new Book();
        List<Book> _oBooks = new List<Book>();

        public BookController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<List<Book>> GetAllBooks()
        {
            _oBooks = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://raw.githack.com/timeiagro/BackendTest/master/books.json"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBooks = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                }
            }
            return _oBooks;
        }

        [HttpGet("{id}")]
        public async Task<List<Book>> GetById(int id)
        {
            _oBooks = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://raw.githack.com/timeiagro/BackendTest/master/books.json"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBooks = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                }
            }

            var finded = _oBooks.FindAll(book => book.id == id);

            return finded;
        }

        [HttpGet("{id}/frete")]
        public async Task<List<Book>> GetFrete(int id)
        {
            _oBooks = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://raw.githack.com/timeiagro/BackendTest/master/books.json"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBooks = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                }
            }

            var finded = _oBooks.FindAll(book => book.id == id);

            finded[0].frete = calculateFrete(finded[0].price);

            // finded[0].frete = finded[0].price + (finded[0].price*20/100);

            return finded;
        }

        [HttpGet("desc")]
        public async Task<List<Book>> GetDescPrice()
        {
            _oBooks = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://raw.githack.com/timeiagro/BackendTest/master/books.json"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBooks = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                }
            }

            var booksInDescOrder = _oBooks.OrderByDescending(book => book.price).ToList();

            return booksInDescOrder;

        }

        [HttpGet("asc")]
        public async Task<List<Book>> GetAscPrice()
        {
            _oBooks = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://raw.githack.com/timeiagro/BackendTest/master/books.json"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBooks = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                }
            }

            var booksInAscOrder = _oBooks.OrderBy(book => book.price).ToList();

            return booksInAscOrder;

        }

        [HttpGet("search")]
        public async Task<List<Book>> GetByName([FromQuery] string name, [FromQuery] string author)
        {
            _oBooks = new List<Book>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://raw.githack.com/timeiagro/BackendTest/master/books.json"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBooks = JsonConvert.DeserializeObject<List<Book>>(apiResponse);
                }
            }

            if (name != null)
            {
                return _oBooks.Where(book => book.name.ToLower().Contains(name.ToLower())).ToList();
            }
            if (author != null)
            {
                return _oBooks.Where(book => book.Specifications.author.ToLower().Contains(author.ToLower())).ToList();
            }

            return _oBooks;


        }        
        private decimal calculateFrete(decimal price)
        {
            decimal frete;

            frete = price+(price*20/100);

            return frete;
        }
    }

}

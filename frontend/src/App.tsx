import React from 'react'
import {Routes, Route} from "react-router-dom";
import Navbar from './components/navbar/Navbar'
import Home from './pages/home/Home.page';
import Products from './pages/products/Products.page';
import Addproduct from './pages/add-product/Addproduct.page';
import Editproduct from './pages/edit-product/Editproduct.page';
import DeleteProduct from './pages/delete-product/DeleteProduct.page';

const App: React.FC = () => {
  return (
    <div>
      {/* Navbar */}
      <Navbar />

      {/* Wrapper */}
      <div className="wrapper">
        <Routes>
          <Route path="/" element={<Home />}/>
          <Route path='/products'>
            <Route index element={<Products />} />
             <Route path='add' element={<Addproduct />} />
             <Route path='edit/:id' element={<Editproduct />} />
             <Route path='delete/:id' element={<DeleteProduct />} />


          </Route>
        </Routes>
      </div>

    </div> 
  )
}

export default App
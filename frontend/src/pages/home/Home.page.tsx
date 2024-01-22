import React from 'react';
import './home.scss';
import {Button} from "@mui/material";
import {useNavigate} from 'react-router-dom';
import kitten from "../../assets/images/kitten.avif"

const Home = () => {
    const redirect =  useNavigate();
  return (
    <div className='Home'>
        <h1>Welcome To Pet Store</h1>
        <Button variant='outlined' color='primary' onClick={()=> redirect("/products")}>
            Products List
        </Button>
        <img src={kitten} alt='kitten' />

    </div>
  )
}

export default Home